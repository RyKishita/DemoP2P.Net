using System;
using UnityEngine;

[Serializable]
public class Settings : ScriptableObject
{
    public string connectionTarget = "local";
    public int portNo = 55555;
    public string param3 = "PeerName";
    public float sendPositionInterval = 0.2f;
}
