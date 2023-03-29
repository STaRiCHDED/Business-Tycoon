using Models;

namespace Services
{
    public class ConfigService : IConfigService
    {
        public int RecalculateUpgradePrice(int level, int basePrice)
        {
            return (level + 1) * basePrice;
        }

        public int RecalculateIncome(int level, int baseIncome,params ImprovementData[] improvements)
        {
            var result = 0;
            foreach (var improvementData in improvements)
            {
                if (improvementData.IsPurchased)
                {
                    result += improvementData.IncomeMultiplier / 100;
                }
            }
            return level * baseIncome * (1 + result);
        }
    }
}