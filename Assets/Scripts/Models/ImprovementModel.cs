namespace Models
{
    public class ImprovementModel
    {
        public string Name { get; }
        public int IncomeMultiplier { get; }
        public int Price { get; }
        public bool IsPurchased { get; private set;}

        public ImprovementModel(ImprovementConfigModel improvementConfigModel)
        {
            Name = improvementConfigModel.Name;
            IncomeMultiplier = improvementConfigModel.IncomeMultiplier;
            Price = improvementConfigModel.Price;
            IsPurchased = improvementConfigModel.IsPurchased;
        }

        public void ChangeState(bool isPurchased)
        {
            IsPurchased = isPurchased;
        }
    }
}