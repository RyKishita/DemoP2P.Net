using System;
using System.Diagnostics;
using System.IO.Pipes;
using UnityEngine;

public class SendPeer : SingletonMonoBehaviour<SendPeer>
{
    Process process = null;
    NamedPipeServerStream namedPipe = null;
    byte[] data = null;

    public byte[] Data
    {
        set
        {
            data = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        try
        {
            const string exeName = "PipeToPeer.exe";

            var settings = ConfigProvider.ConfigComponent.Settings;
            string pipeName = Guid.NewGuid().ToString();

            namedPipe = new NamedPipeServerStream(pipeName);
            namedPipe.BeginWaitForConnection(new AsyncCallback(result => (result.AsyncState as SendPeer).BeginWaitForConnectionCallback(result)), this);

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

    private void BeginWaitForConnectionCallback(IAsyncResult result)
    {
        namedPipe.EndWaitForConnection(result);

        UnityEngine.Debug.Log(nameof(BeginWaitForConnectionCallback));
    }

    float updateTotalTime = 0.0f;
    volatile bool bWriting = false;

    private async void Update()
    {
        if (bWriting) return;
        bWriting = true;

        try
        {
            updateTotalTime += Time.deltaTime;
            if (updateTotalTime < ConfigProvider.ConfigComponent.Settings.sendPositionInterval) return;
            updateTotalTime = 0.0f;

            await namedPipe.WriteAsync(data, 0, data.Length);
        }
        finally
        {
            bWriting = false;
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
        if (null != namedPipe)
        {
            namedPipe.Disconnect();
            namedPipe.Dispose();
            namedPipe = null;
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
