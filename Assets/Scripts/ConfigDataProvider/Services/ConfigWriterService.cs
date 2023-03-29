using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ConfigWriterService : IConfigWriterService
{
    private CustomDateTimeConverter _customDateTimeConverter = new CustomDateTimeConverter();
    private readonly string ConfigReaderPath = "Assets/Scripts/ConfigDataProvider/Data/Saves.json";
    
    public void WriteConfig(ConfigData data)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>{_customDateTimeConverter}
        };
        var jsonData = JsonConvert.SerializeObject(data,Formatting.Indented,settings);
        File.WriteAllText(ConfigReaderPath,jsonData);
    }
}