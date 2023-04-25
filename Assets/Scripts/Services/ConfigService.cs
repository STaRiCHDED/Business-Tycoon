using System.Collections.Generic;
using Models;

namespace Services
{
    public class ConfigService : IConfigService
    {
        public List<BusinessModel> BusinessModels { get; private set; }

        private readonly BusinessesConfig _businessesConfig;

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
                return BusinessModels;
            }

            BusinessModels = businessModels;
            return BusinessModels;
        }

        private List<ImprovementModel> CreateImprovementModels(BusinessConfigModel businessConfigModel)
        {
            var improvementModels = new List<ImprovementModel>();

            foreach (var improvementConfigModel in businessConfigModel.Improvements)
            {
                var improvementName = improvementConfigModel.Name;
                var improvementIncomeMultiplier = improvementConfigModel.IncomeMultiplier;
                var improvementPrice = improvementConfigModel.Price;
                var improvementIsPurchased = improvementConfigModel.IsPurchased;

                var improvementModel = new ImprovementModel(improvementName, improvementIncomeMultiplier,
                    improvementPrice, improvementIsPurchased);

                improvementModels.Add(improvementModel);
            }

            return improvementModels;
        }

        private void CreateBusinessModels()
        {
            BusinessModels = new List<BusinessModel>();
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

                BusinessModels.Add(businessModel);
            }
        }
    }
}