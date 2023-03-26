namespace Models
{
    public class ImprovementModel
    {
        private string _name;
        private int _incomeMultiplier;
        private int _price;
        private bool _isPurchased;

        public ImprovementModel(ImprovementConfigModel improvementConfigModel)
        {
            _name = improvementConfigModel.Name;
            _incomeMultiplier = improvementConfigModel.IncomeMultiplier;
            _price = improvementConfigModel.Price;
            _isPurchased = improvementConfigModel.IsPurchased;
        }
    }
}