using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IConfigService : IService
    {
        public List<BusinessModel> BusinessModels { get; }
        public PlayerBalanceModel CreatePlayerBalanceModel(float balance);
        public List<BusinessModel> GetBusinessModels(List<BusinessModel> businessModels = null);
        
    }
}