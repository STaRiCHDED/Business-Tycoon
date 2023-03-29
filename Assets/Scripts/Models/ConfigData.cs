using System;
using System.Collections.Generic;
using Models;
using Newtonsoft.Json;

public class ConfigData
{
    [JsonProperty("endTime")] 
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime EndTime { get; set;}
    [JsonProperty("balance")] 
    public int Balance { get; set;}
    [JsonProperty("businesses")] 
    public List<BusinessData> Businesses { get; set;}
}