using Newtonsoft.Json;

namespace Models
{
    public class ImprovementData
    {
        [JsonProperty("name")] public string Name{ get; set;}
        [JsonProperty("isPurchased")] public bool IsPurchased{ get; set;}
        [JsonProperty("incomeMultiplier")] public int IncomeMultiplier{ get; set;}
        [JsonProperty("price")] public int Price{ get; set;}
    }
}