using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using UnityEngine;

public class ReceivePeer : SingletonMonoBehaviour<ReceivePeer>
{
    public GameObject otherPlayer;

    Process process = null;
    NamedPipeServerStream namedPipePeerToPipe = null;
    NamedPipeServerStream namedPipePipeToPeer = null;
    Dictionary<string, PlayerData> otherPlayerDatas = new Dictionary<string, PlayerData>();
    Dictionary<string, OtherPlayerController> otherPlayers = new Dictionary<string, OtherPlayerController>();

    protected override void Awake()
    {
        base.Awake();

        try
        {
            var settings = ConfigProvider.ConfigComponent.Settings;
            string pipeName = Guid.NewGuid().ToString();

            const string exeName = "PeerToPipe.exe";

            var beginWaitForConnectionCallback = new AsyncCallback(result => (result.AsyncState as NamedPipeServerStream).EndWaitForConnection(result));

            namedPipePeerToPipe = new NamedPipeServerStream(pipeName + "PeerToPipe");
            namedPipePeerToPipe.BeginWaitForConnection(beginWaitForConnectionCallback, namedPipePeerToPipe);

            namedPipePipeToPeer = new NamedPipeServerStream(pipeName + "PipeToPeer");
            namedPipePipeToPeer.BeginWaitForConnection(beginWaitForConnectionCallback, namedPipePipeToPeer);

            var info = new ProcessStartInfo()
            {
                FileName = System.IO.Path.Combine(Application.streamingAssetsPath, exeName),
                Arguments = $"{pipeName} {settings.connectionTarget} {settings.portNo} {settings.param3}",
#if !DEBUG
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
#endif
            };
            process = Process.Start(info);
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogException(ex);
        }
    }

    float updateTotalTime = 0.0f;
    volatile bool bReading = false;

    private async void Update()
    {
        if (bReading) return;
        bReading = true;
        UnityEngine.Debug.Log("peer reading start");

        try
        {
            if (!namedPipePipeToPeer.IsConnected) return;
            if (!namedPipePeerToPipe.IsConnected) return;

            updateTotalTime += Time.deltaTime;
            if (updateTotalTime < ConfigProvider.ConfigComponent.Settings.sendPositionInterval) return;
            updateTotalTime = 0.0f;

            byte[] writeBuffer =  { 0xFF };
            await namedPipePipeToPeer.WriteAsync(writeBuffer, 0, writeBuffer.Length);//読み取り実行
            namedPipePipeToPeer.WaitForPipeDrain();

            while(true)
            {
                var readBuffer = new byte[4096];
                int length = await namedPipePeerToPipe.ReadAsync(readBuffer, 0, readBuffer.Length);
                if (1 == length && readBuffer[0] == 0xFF) break;

                var receiveBuffer = new byte[length];
                Buffer.BlockCopy(readBuffer, 0, receiveBuffer, 0, length);

                var data = Serializer.Deserialize<PlayerData>(receiveBuffer);
                if (null != data)
                {
                    lock (otherPlayerDatas)
                    {
                        data.IsModify = true;
                        otherPlayerDatas[data.ID] = data;
                    }
                }
            }
        }
        finally
        {
            bReading = false;
            UnityEngine.Debug.Log("peer reading end");
        }
    }

    private void FixedUpdate()
    {
        var newPlayers = new List<PlayerData>();
        lock (otherPlayerDatas)
        {
            string playerID = PlayerController.Instance.PlayerData.ID;
            foreach (var pair in otherPlayerDatas)
            {
                if (pair.Key == playerID) continue;

                OtherPlayerController otherplayer;
                if (otherPlayers.TryGetValue(pair.Key, out otherplayer))
                {
                    if (pair.Value.IsModify)
                    {
                        pair.Value.IsModify = false;
                        otherplayer.transform.position = new Vector3(pair.Value.X, otherplayer.transform.position.y, pair.Value.Z);
                    }
                }
                else
                {
                    newPlayers.Add(pair.Value);
                }
            }
        }

        foreach (var playerdata in newPlayers)
        {
            var obj = Instantiate(otherPlayer, new Vector3(playerdata.X, otherPlayer.transform.position.y, playerdata.Z), Quaternion.identity);
            var newOtherPlayer = obj.GetComponent<OtherPlayerController>();
            newOtherPlayer.PlayerData = playerdata;
            otherPlayers[playerdata.ID] = newOtherPlayer;
        }
    }

    private void OnDestroy()
    {
        Dispose();
    }

    public void OnApplicationQuit()
    {
        Dispose();
    }

    private void Dispose()
    {
        if (null != namedPipePeerToPipe)
        {
            namedPipePeerToPipe.Disconnect();
            namedPipePeerToPipe.Dispose();
            namedPipePeerToPipe = null;
        }

        if (null != namedPipePipeToPeer)
        {
            namedPipePipeToPeer.Disconnect();
            namedPipePipeToPeer.Dispose();
            namedPipePipeToPeer = null;
        }

        if (null != process)
        {
            process.WaitForExit(2000);
            //process.Kill();
            process.Dispose();
            process = null;
        }
    }
}
