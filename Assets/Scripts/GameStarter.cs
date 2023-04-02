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

    private IFileService _fileService;
    private SaveDataModel _saveDataModel;

    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;

        serviceLocator.RegisterSingle<IConfigService>(new ConfigService(_businessesConfig));

        var configService = serviceLocator.GetSingle<IConfigService>();
        serviceLocator.RegisterSingle<IFileService>(new FileService(configService));

        _fileService = serviceLocator.GetSingle<IFileService>();
        _saveDataModel = _fileService.Load();
        
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(_saveDataModel.PlayerBalanceModel));
        
        _businessesSpawner.Spawn(_saveDataModel.BusinessModels);
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fileService.Save(_saveDataModel);
        }
    }
}