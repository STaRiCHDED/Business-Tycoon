using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ImprovementConfigModel
    {
        public string Name => _name;
   
        public float IncomeMultiplier => _incomeMultiplier;

        public float Price => _price;

        public bool IsPurchased => _isPurchased;
   
        [SerializeField]
        private string _name;
   
        [SerializeField]
        private float _incomeMultiplier;

        [SerializeField]
        private float _price;

        [SerializeField]
        private bool _isPurchased;
    }
}