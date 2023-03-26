using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BusinessConfigModel
    {
    
        public string Name => _name;
   
        public int Level => _level;
   
        public int Income => _income;

        public int IncomeDelay => _incomeDelay;

        public int UpgradePrice => _upgradePrice;

        public IReadOnlyList<ImprovementConfigModel> Improvements => _improvements;
   
        [SerializeField]
        private string _name;
   
        [SerializeField]
        private int  _level;
   
        [SerializeField]
        private int _income;

        [SerializeField]
        private int _incomeDelay;

        [SerializeField]
        private int _upgradePrice;

        [SerializeField]
        private List<ImprovementConfigModel> _improvements;
        
    }
}