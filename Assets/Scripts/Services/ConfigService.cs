using System.Collections.Generic;
using Models;

namespace Services
{
    public class ConfigService : IConfigService
    {
        private readonly BusinessesConfig _businessesConfig;
        private List<BusinessModel> _businessModels = new();

        public ConfigService(BusinessesConfig businessesConfig)
        {
            _businessesConfig = businessesConfig;
        }

        public PlayerBalanceModel CreatePlayerBalanceModel(float balance)
        {
            return new PlayerBalanceModel(balance);
        }

        public List<BusinessModel> GetBusinessModels(List<BusinessModel> businessModels)
        {
            if (businessModels == null)
            {
                CreateBusinessModels();
                return _businessModels;
            }

            _businessModels = businessModels;
            return _businessModels;
        }

        public float RecalculateUpgradeLevelPrice(BusinessModel businessModel)
        {
            return (businessModel.CurrentLevel + 1) * businessModel.BasePrice;
        }

        public float RecalculateIncome(BusinessModel businessModel)
        {
            var incomeMultiplier = 1f;
            foreach (var improvement in businessModel.Improvements)
            {
                incomeMultiplier += improvement.IsPurchased ? improvement.IncomeMultiplier / 100 : 0;
            }

            return businessModel.CurrentLevel * businessModel.BaseIncome * incomeMultiplier;
        }

        private List<ImprovementModel> CreateImprovementModels(BusinessConfigModel businessConfigModel)
        {
            var improvementModels = new List<ImprovementModel>();
            
            foreach (var improvementConfigModel in businessConfigModel.Improvements)
            {
                improvementModels.Add(new ImprovementModel(improvementConfigModel.Name,
                    improvementConfigModel.IncomeMultiplier,
                    improvementConfigModel.Price, improvementConfigModel.IsPurchased));
            }

            return improvementModels;
        }

        private void CreateBusinessModels()
        {
            _businessModels = new List<BusinessModel>();
            foreach (var businessConfigModel in _businessesConfig.Businesses)
            {
                var businessName = businessConfigModel.Name;
                var businessBasePrice = businessConfigModel.UpgradePrice;
                var businessBaseIncome = businessConfigModel.Income;
                var businessIncomeDelay = businessConfigModel.IncomeDelay;
                var businessLevel = businessConfigModel.Level;
                var businessCurrentIncome = businessConfigModel.Income;
                var businessCurrentPrice = businessConfigModel.UpgradePrice;
                var improvementModels = CreateImprovementModels(businessConfigModel);

                var businessModel = new BusinessModel(businessName, businessBasePrice, businessBaseIncome,
                    businessIncomeDelay, businessLevel, businessCurrentIncome, businessCurrentPrice, improvementModels);

                _businessModels.Add(businessModel);
            }
        }
    }
}