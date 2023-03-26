namespace Services
{
    public interface IConfigService : IService
    {
        int RecalculateUpgradePrice(int level, int basePrice);
        int RecalculateIncome(int level, int baseIncome, int firstImprovementBoost, int secondImprovementBoost);
    }
}