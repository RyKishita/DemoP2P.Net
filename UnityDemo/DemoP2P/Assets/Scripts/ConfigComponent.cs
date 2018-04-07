using UnityEngine;

public class ConfigComponent : SingletonMonoBehaviour<ConfigComponent>
{
    private readonly string basePath = "Config/";

    private Settings settings;

    public Settings Settings
    {
        get { return settings ?? (settings = LoadConfig()); }
    }

    private Settings LoadConfig()
    {
        return Resources.Load<Settings>(basePath + "Settings");
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

}
