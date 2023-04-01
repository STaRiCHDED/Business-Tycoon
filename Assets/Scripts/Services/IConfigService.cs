using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IConfigService : IService
    {
        public PlayerBalanceModel CreatePlayerBalanceModel(float balance);
        public List<BusinessModel> GetBusinessModels(List<BusinessModel> businessModels = null);

        public float RecalculateUpgradeLevelPrice(BusinessModel businessModel);
       public float RecalculateIncome(BusinessModel businessModel);
    }
}