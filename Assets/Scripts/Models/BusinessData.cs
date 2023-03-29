using Newtonsoft.Json;

namespace Models
{
    public class BusinessData
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("currentLevel")] public int Level{ get; set;}
        [JsonProperty("currentIncome")] public int Income{ get; set;}
        [JsonProperty("currentIncomeDelay")] public int IncomeDelay{ get; set;}
        [JsonProperty("currentUpgradePrice")] public int UpgradePrice{ get; set;}
    
        [JsonProperty("improvements")] public ImprovementData[] Improvements { get; set; }

        [JsonProperty("basePrice")] public int BasePrice{ get; set;}
        [JsonProperty("baseIncome")] public int BaseIncome{ get; set;}
    }
}