using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ConfigReaderService : IConfigReaderService
{
    private readonly string InstanceReaderPath = "Assets/Scripts/ConfigDataProvider/Data/InitialData.json";
    private readonly string ConfigReaderPath = "Assets/Scripts/ConfigDataProvider/Data/saves.json";
    public ConfigData ReadConfig()
    {
        var jsonData = File.ReadAllText(ConfigReaderPath);
        Debug.Log(jsonData);
        ConfigData data = JsonConvert.DeserializeObject<ConfigData>(jsonData);
        return data;
    }

    public ConfigData ReadInstanceData()
    {
        var jsonData = File.ReadAllText(InstanceReaderPath);
        Debug.Log(jsonData);
        ConfigData data = JsonConvert.DeserializeObject<ConfigData>(jsonData);
        return data;
    }
}