using System;

[Serializable]
public class PlayerData
{
    public string ID { get; set; } = Guid.NewGuid().ToString();
    public float X { get; set; } = float.NaN;
    public float Z { get; set; } = float.NaN;
    public bool IsModify { get; set; } = false;
}
