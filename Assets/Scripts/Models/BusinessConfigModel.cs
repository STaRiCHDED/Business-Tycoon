using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BusinessConfigModel
    {
    
        public string Name => _name;
   
        public float Level => _level;
   
        public float Income => _income;

        public float IncomeDelay => _incomeDelay;

        public float UpgradePrice => _upgradePrice;

        public IReadOnlyList<ImprovementConfigModel> Improvements => _improvements;
   
        [SerializeField]
        private string _name;
   
        [SerializeField]
        private float  _level;
   
        [SerializeField]
        private float _income;

        [SerializeField]
        private float _incomeDelay;

        [SerializeField]
        private float _upgradePrice;

        [SerializeField]
        private List<ImprovementConfigModel> _improvements;
        
    }
}