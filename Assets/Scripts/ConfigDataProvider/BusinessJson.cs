using Newtonsoft.Json;
public class BusinessJson
{
    [JsonProperty("name")] 
    public string Name { get; set;}
    [JsonProperty("level")] 
    public int Level { get; set;}
    [JsonProperty("improvements")] 
    public ImprovementsJson[] Improvements { get; set;}
}