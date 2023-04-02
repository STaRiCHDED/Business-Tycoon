using System;

namespace Models
{
    [Serializable]
    public class ImprovementModel
    {
        public string Name { get; }
        public float IncomeMultiplier { get; }
        public float Price { get; }
        public bool IsPurchased { get; set; }

        public ImprovementModel(string name, float incomeMultiplier, float price, bool isPurchased)
        {
            Name = name;
            IncomeMultiplier = incomeMultiplier;
            Price = price;
            IsPurchased = isPurchased;
        }
    }
}