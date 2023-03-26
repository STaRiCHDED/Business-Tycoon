using System.Collections.Generic;

namespace Models
{
    public class BusinessModel
    {
        public string Name { get; }
        public int CurrentLevel { get; private set; }
        public int CurrentIncome { get; private set; }
        public int CurrentIncomeDelay { get; }
        public int CurrentUpgradePrice { get; private set; }

        public IReadOnlyList<ImprovementModel> Improvements => _improvements;
        
        private List<ImprovementModel> _improvements = new();
        
        public BusinessModel(BusinessConfigModel businessConfigModel)
        {
            Name = businessConfigModel.Name;
            CurrentLevel = businessConfigModel.Level;
            CurrentIncome = businessConfigModel.Income;
            CurrentIncomeDelay = businessConfigModel.IncomeDelay;
            CurrentUpgradePrice = businessConfigModel.UpgradePrice;
            foreach (var improvementConfigModel in businessConfigModel.Improvements)
            {
                _improvements.Add(new ImprovementModel(improvementConfigModel));
            }
        }

        public void UpdateLevel()
        {
            CurrentLevel++;
        }

        public void UpdatePrice(int newPrice)
        {
            CurrentUpgradePrice = newPrice;
        }

        public void UpdateIncome(int newIncome)
        {
            CurrentIncome = newIncome;
        }
    }
}