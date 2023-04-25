using Models;

namespace Services
{
    public class GameDataProvider : IGameDataProvider
    {
        private readonly IConfigService _configService;
        private readonly IBalanceService _balanceService;

        public GameDataProvider(IConfigService configService, IBalanceService balanceService)
        {
            _configService = configService;
            _balanceService = balanceService;
        }

        public SaveDataModel GetCurrentData()
        {
            var businessModels = _configService.BusinessModels;
            var playerBalanceModel = _balanceService.PlayerBalanceModel;
            var saveData = new SaveDataModel(playerBalanceModel, businessModels);
            return saveData;
        }
    }
}