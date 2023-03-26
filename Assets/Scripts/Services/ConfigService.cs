namespace Services
{
    public class ConfigService : IConfigService
    {
        public int RecalculateUpgradePrice(int level, int basePrice)
        {
            return (level + 1) * basePrice;
        }

        public int RecalculateIncome(int level, int baseIncome, int firstImprovementBoost, int secondImprovementBoost)
        {
            return level * baseIncome * (1 + firstImprovementBoost + secondImprovementBoost);
        }
    }
}