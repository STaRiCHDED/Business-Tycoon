using Models;

namespace Services
{
    public interface IRecalculationService : IService
    {
        public float RecalculateUpgradeLevelPrice(BusinessModel businessModel);
        public float RecalculateIncome(BusinessModel businessModel);
    }
}