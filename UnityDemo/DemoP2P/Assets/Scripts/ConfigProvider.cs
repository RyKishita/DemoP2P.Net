using UnityEngine;

public static class ConfigProvider
{
    private const string path = "Utilities/ConfigProvider";

    private static ConfigComponent _confgiComponent;

    public static ConfigComponent ConfigComponent
    {
        get
        {
            if (null == _confgiComponent)
            {
                if (ConfigComponent.Instance == null)
                {
                    var resource = Resources.Load(path);
                    Object.Instantiate(resource);
                }
                _confgiComponent = ConfigComponent.Instance;
            }
            return _confgiComponent;
        }
    }
}
