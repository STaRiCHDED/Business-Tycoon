using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class ConfigService : IConfigService
    {
        private readonly BusinessesConfig _businessesConfig;
        private List<BusinessModel> _businessModels;

        public ConfigService(BusinessesConfig businessesConfig)
        {
            _businessesConfig = businessesConfig;
        }

        public IReadOnlyList<BusinessModel> CreateBusinessModels()
        {
            _businessModels = new List<BusinessModel>();
            foreach (var configModel in _businessesConfig.Businesses)
            {
                _businessModels.Add(new BusinessModel(configModel));
            }

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
    }
}