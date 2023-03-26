using System;
using Services;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Awake()
    {
        var serviceLocator = new ServiceLocator();
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService());
        serviceLocator.RegisterSingle<IConfigService>(new ConfigService());
        serviceLocator.RegisterSingle<IConfigReaderService>(new ConfigReaderService());
        serviceLocator.RegisterSingle<IConfigWriterService>(new ConfigWriterService());
    }
}