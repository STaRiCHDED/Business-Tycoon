using Models;
using Services;
using UnityEngine;
using Views;

public class GameStarter : MonoBehaviour
{
    [SerializeField] 
    private BusinessesSpawner _businessesSpawner;

    private void Awake()
    {
        RegisterServices();
        _businessesSpawner.Spawn();
    }

    private void RegisterServices()
    {
        var serviceLocator = ServiceLocator.Instance;

        serviceLocator.RegisterSingle<IFileService>(new FileService());
        serviceLocator.RegisterSingle<IConfigService>(new ConfigService());

        var playerBalanceModel = new PlayerBalanceModel();
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(playerBalanceModel));
    }
}