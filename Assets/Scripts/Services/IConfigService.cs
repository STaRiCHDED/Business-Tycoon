namespace Services
{
    public interface IConfigService : IService
    {
        int RecalculateUpgradePrice(int level, int basePrice);
        int RecalculateIncome(int level, int baseIncome, 
            bool isFirstPurchased, int firstImprovementBoost,
            bool isSecondPurchased, int secondImprovementBoost);
    }
}