namespace Models
{
    public class ImprovementModel
    {
        public string Name { get; }
        public int IncomeMultiplier { get; }
        public int Price { get; }
        public bool IsPurchased { get; }

        public ImprovementModel(ImprovementConfigModel improvementConfigModel)
        {
            Name = improvementConfigModel.Name;
            IncomeMultiplier = improvementConfigModel.IncomeMultiplier;
            Price = improvementConfigModel.Price;
            IsPurchased = improvementConfigModel.IsPurchased;
        }
    }
}