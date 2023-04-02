using IngameStateMachine;
using Models;
using Services;

public class InitializationState : IState
{
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public ServiceLocator RegisterServices()
    {
        var serviceLocator = ServiceLocator.Instance;
        
        serviceLocator.RegisterSingle<IAssetProvider>(new AssetProvider());
        var assetProvider = serviceLocator.GetSingle<IAssetProvider>();

        var config = assetProvider.Load<BusinessesConfig>(ResourcesNames.CONFIG);
        serviceLocator.RegisterSingle<IConfigService>(new ConfigService(config));
        
        var configService = serviceLocator.GetSingle<IConfigService>();
        serviceLocator.RegisterSingle<IFileService>(new FileService(configService));
        
        serviceLocator.RegisterSingle<IRecalculationService>(new RecalculationService());
        
        return serviceLocator;
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