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
        var data = ServiceLocator.Instance.GetSingle<IConfigReaderService>().ReadConfig();
        Debug.Log($"Save data\nTime:{data.EndTime}\nBalance:{data.Balance}");
        foreach (var dataBusiness in data.Businesses)
        {
            Debug.Log($"Business:{dataBusiness.Name}" +
                      $"\nLevel:{dataBusiness.Level}" +
                      $"\nIncome:{dataBusiness.Income}" +
                      $"\nIncomeDelay:{dataBusiness.IncomeDelay}\nBalance:{dataBusiness.Improvements[0]} {dataBusiness.Improvements[1]}");
        }
        data.EndTime = DateTime.UtcNow;
        data.Balance = 200000;
        ServiceLocator.Instance.GetSingle<IConfigWriterService>().WriteConfig(data);
    }
}