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

        public ImprovementModel(ImprovementConfigModel configModel)
        {
            Name = configModel.Name;
            IncomeMultiplier = configModel.IncomeMultiplier;
            Price = configModel.Price;
            IsPurchased = configModel.IsPurchased;
        }
    }
}