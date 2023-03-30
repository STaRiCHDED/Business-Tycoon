using Models;

namespace Services
{
    public interface IConfigService : IService
    {
       public float RecalculateUpgradePrice(BusinessModel businessModel);
       public float RecalculateIncome(BusinessModel businessModel);
    }
}