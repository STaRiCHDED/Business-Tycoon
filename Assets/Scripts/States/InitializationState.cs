using IngameStateMachine;
using Models;
using Services;

namespace States
{
    public class InitializationState : IState
    {
        private StateMachine _stateMachine;

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void RegisterServices()
        {
            var serviceLocator = ServiceLocator.Instance;

            serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider());
            var assetProvider = serviceLocator.GetSingle<IAssetProvider>();

            var config = assetProvider.Load<BusinessesConfig>(ResourcesNames.CONFIG);
            serviceLocator.RegisterSingle<IConfigService>(new ConfigService(config));

            serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(new PlayerBalanceModel(0)));

            var configService = serviceLocator.GetSingle<IConfigService>();
            var balanceService = serviceLocator.GetSingle<IBalanceService>();

            serviceLocator.RegisterSingle<IGameDataProvider>(new GameDataProvider(configService, balanceService));

            serviceLocator.RegisterSingle<IFileService>(new FileService());
            serviceLocator.RegisterSingle<IRecalculationService>(new RecalculationService());
        }

        public void OnEnter()
        {
            _stateMachine.Enter<StartState>();
        }

        public void OnExit()
        {
        }

        public void Dispose()
        {
        }
    }
}