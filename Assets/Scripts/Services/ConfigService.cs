namespace Services
{
    public class ConfigService : IConfigService
    {
        public int RecalculateUpgradePrice(int level, int basePrice)
        {
            return (level + 1) * basePrice;
        }

        public int RecalculateIncome(int level, int baseIncome,
            bool isFirstPurchased, int firstImprovementBoost,
            bool isSecondPurchased, int secondImprovementBoost)
        {
            firstImprovementBoost = isFirstPurchased ? firstImprovementBoost : 0;
            secondImprovementBoost = isSecondPurchased ? secondImprovementBoost : 0;
            return level * baseIncome * (1 + firstImprovementBoost/100 + secondImprovementBoost/100);
        }
    }
}