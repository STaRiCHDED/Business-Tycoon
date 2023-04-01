using System;
using System.Collections.Generic;
using Services;
using UnityEditor;

namespace Models
{
    [Serializable]
    public class BusinessModel
    {
        public string Name { get; }
        public float BasePrice { get; }
        public float BaseIncome { get; }
        public float IncomeDelay { get; }

        public float CurrentLevel { get; set; }
        public float CurrentIncome { get; set; } 
        public float CurrentUpgradePrice { get; set; }
        public List<ImprovementModel> Improvements { get; }
        

        public BusinessModel(string name, float basePrice, float baseIncome, float incomeDelay,
            float level, float income, float price, List<ImprovementModel> improvements)
        {
            Name = name;
            BasePrice = basePrice;
            BaseIncome = baseIncome;
            IncomeDelay = incomeDelay;

            CurrentLevel = level;
            CurrentIncome = income;
            CurrentUpgradePrice = price;

            Improvements = improvements;
        }

    }
}