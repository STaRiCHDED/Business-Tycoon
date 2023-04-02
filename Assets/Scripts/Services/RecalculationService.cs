using Models;

namespace Services
{
    public class RecalculationService : IRecalculationService
    {
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