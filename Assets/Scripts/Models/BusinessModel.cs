using System.Collections.Generic;

namespace Models
{
    public class BusinessModel
    {
        private string _name;
        private int _currentLevel;
        private int _currentIncome;
        private int _currentIncomeDelay;
        private int _currentUpgradePrice;
        private List<ImprovementModel> _improvements = new();
        
        public BusinessModel(BusinessConfigModel businessConfigModel)
        {
            _name = businessConfigModel.Name;
            _currentLevel = businessConfigModel.Level;
            _currentIncome = businessConfigModel.Income;
            _currentIncomeDelay = businessConfigModel.IncomeDelay;
            _currentUpgradePrice = businessConfigModel.UpgradePrice;
            for (var i = 0; i < businessConfigModel.Improvements.Count; i++)
            {
                _improvements[i] = new ImprovementModel(businessConfigModel.Improvements[i]);
            }
        }
    }
}