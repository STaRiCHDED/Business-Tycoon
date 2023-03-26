using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ImprovementConfigModel
    {
        public string Name => _name;
   
        public int IncomeMultiplier => _incomeMultiplier;

        public int Price => _price;

        public bool IsPurchased => _isPurchased;
   
        [SerializeField]
        private string _name;
   
        [SerializeField]
        private int _incomeMultiplier;

        [SerializeField]
        private int _price;

        [SerializeField]
        private bool _isPurchased;
    }
}