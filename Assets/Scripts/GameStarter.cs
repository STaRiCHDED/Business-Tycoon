using System;
using Models;
using Services;
using UnityEngine;
using Views;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private BusinessesConfig _businessesConfig;
    
    [SerializeField] 
    private BusinessesSpawner _businessesSpawner;

    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;

        serviceLocator.RegisterSingle<IFileService>(new FileService());
        serviceLocator.RegisterSingle<IConfigService>(new ConfigService(_businessesConfig));
        
        var fileService = serviceLocator.GetSingle<IFileService>();
        var saveData = fileService.Load();
        var configService = serviceLocator.GetSingle<IConfigService>();
        if (saveData==null)
        {
            var playerBalanceModel = new PlayerBalanceModel();
            serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(playerBalanceModel));
            _businessesSpawner.Spawn(configService.CreateBusinessModels());

        }
        else
        {
            serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(saveData.PlayerBalanceModel));
            _businessesSpawner.Spawn(saveData.BusinessModels);
        }
    }
}