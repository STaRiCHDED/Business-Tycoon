using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IConfigService : IService
    {
        public IReadOnlyList<BusinessModel> CreateBusinessModels();
        public float RecalculateUpgradePrice(BusinessModel businessModel);
       public float RecalculateIncome(BusinessModel businessModel);
    }
}