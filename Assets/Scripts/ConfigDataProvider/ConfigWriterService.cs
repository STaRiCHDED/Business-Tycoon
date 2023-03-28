using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ConfigWriterService : IConfigWriterService
{
    private CustomDateTimeConverter _customDateTimeConverter = new CustomDateTimeConverter();
    
    public void WriteConfig(BusinessDataJson dataJson)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>{_customDateTimeConverter}
        };
        var jsonData = JsonConvert.SerializeObject(dataJson,Formatting.Indented,settings);
        File.WriteAllText("Assets/Scripts/ConfigDataProvider/saves.json",jsonData);
    }
}