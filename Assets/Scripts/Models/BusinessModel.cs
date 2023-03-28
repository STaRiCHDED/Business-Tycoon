using System.Collections.Generic;
using Services;

namespace Models
{
    public class BusinessModel
    {
        public int BasePrice { get; }
        public int BaseIncome { get; }
        
        public string Name { get; }
        public int CurrentLevel { get; private set; }
        public int CurrentIncome { get; }
        public int CurrentIncomeDelay { get; }
        public int CurrentUpgradePrice { get; }

        public IReadOnlyList<ImprovementModel> Improvements => _improvements;
        
        private readonly List<ImprovementModel> _improvements = new();
        private IConfigService _configService;
        
        public BusinessModel(BusinessConfigModel businessConfigModel)
        {
            _configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            
            BasePrice = businessConfigModel.UpgradePrice;
            BaseIncome = businessConfigModel.Income;
            
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

        public void UpdateModel(BusinessJson updatedData)
        {
            CurrentLevel = updatedData.Level;
            var improvementsDictionary = new Dictionary<string, ImprovementsJson>();
            foreach (var updatedDataImprovement in updatedData.Improvements)
            {
                improvementsDictionary.Add(updatedDataImprovement.Name,updatedDataImprovement);
            }
            foreach (var improvementModel in _improvements)
            {
                improvementModel.ChangeState(improvementsDictionary[improvementModel.Name].IsPurchased);
            }

        }
        public void UpdateLevel()
        {
            CurrentLevel++;
        }

        public void UpdatePrice()
        {
            _configService.RecalculateUpgradePrice(CurrentLevel, BasePrice);
        }

        public void UpdateIncome()
        {
            var firstImprovement = Improvements[0];
            var secondImprovement = Improvements[1];
            _configService.RecalculateIncome(CurrentLevel, BaseIncome,
                firstImprovement.IsPurchased, firstImprovement.IncomeMultiplier,
                secondImprovement.IsPurchased, secondImprovement.IncomeMultiplier);
        }
    }
}