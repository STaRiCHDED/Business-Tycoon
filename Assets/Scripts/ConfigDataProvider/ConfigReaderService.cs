using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ConfigReaderService : IConfigReaderService
{
    public BusinessData ReadConfig()
    {
        var jsonData = File.ReadAllText("Assets/Scripts/ConfigDataProvider/saves.json");
        Debug.Log(jsonData);
        BusinessData data = JsonConvert.DeserializeObject<BusinessData>(jsonData);
        return data;
    }
}