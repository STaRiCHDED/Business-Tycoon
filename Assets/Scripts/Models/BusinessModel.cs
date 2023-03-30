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
        public IReadOnlyList<ImprovementModel> Improvements => _improvements;
        private readonly List<ImprovementModel> _improvements = new();

        public BusinessModel(BusinessConfigModel configModel)
        {
            Name = configModel.Name;
            BasePrice = configModel.UpgradePrice;
            BaseIncome = configModel.Income;
            IncomeDelay = configModel.IncomeDelay;

            CurrentLevel = configModel.Level;
            CurrentIncome = configModel.Income;
            CurrentUpgradePrice = configModel.UpgradePrice;
            
            foreach (var configModelImprovement in configModel.Improvements)
            {
                _improvements.Add(new ImprovementModel(configModelImprovement));
            }
        }

    }
}