using Newtonsoft.Json;
public class Business
{
    [JsonProperty("name")] 
    public string Name { get; set;}
    [JsonProperty("level")] 
    public int Level { get; set;}
    [JsonProperty("incomeDelay")] 
    public int IncomeDelay { get; set;}
    [JsonProperty("income")] 
    public int Income { get; set;}
    [JsonProperty("improvements")] 
    public bool[] Improvements { get; set;}
}