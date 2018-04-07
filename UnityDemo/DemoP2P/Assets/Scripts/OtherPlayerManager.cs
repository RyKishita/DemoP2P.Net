using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerManager : SingletonMonoBehaviour<OtherPlayerManager>
{
    public GameObject otherPlayerPrefab;

    Dictionary<string, GameObject> createdOtherPlayers = new Dictionary<string, GameObject>();

    private void FixedUpdate()
    {
        byte[] data;
        if (!ReceivePeer.Instance.Queue.TryDequeue(out data)) return;

        var playerData = Serializer.Deserialize<PlayerData>(data);
        if (null == playerData) return;
        if (playerData.ID == PlayerController.Instance.PlayerData.ID) return;

        GameObject otherplayer;
        if (createdOtherPlayers.TryGetValue(playerData.ID, out otherplayer))
        {
            otherplayer.transform.position = new Vector3(playerData.X, otherplayer.transform.position.y, playerData.Z);
        }
        else
        {
            var position = new Vector3(playerData.X, otherPlayerPrefab.transform.position.y, playerData.Z);
            createdOtherPlayers[playerData.ID] = Instantiate(otherPlayerPrefab, position, Quaternion.identity);
        }
    }
}
