using Newtonsoft.Json;

public class ImprovementsJson
{
    [JsonProperty("name")] 
    public string Name;
    [JsonProperty("isPurchased")] 
    public bool IsPurchased;
}