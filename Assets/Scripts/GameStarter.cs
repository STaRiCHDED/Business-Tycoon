using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Awake()
    {
        var serviceLocator = new ServiceLocator();
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService());
        serviceLocator.RegisterSingle<IConfigReaderService>(new ConfigReaderService());
        serviceLocator.RegisterSingle<IConfigWriterService>(new ConfigWriterService());
        var data = ServiceLocator.Instance.GetSingle<IConfigReaderService>().ReadConfig();
        Debug.Log($"Save data\nTime:{data.EndTime}\nBalance:{data.Balance}");
        foreach (var dataBusiness in data.Businesses)
        {
            Debug.Log($"Business:{dataBusiness.Name}" +
                      $"\nBalance:{dataBusiness.Level}" +
                      $"\nBalance:{dataBusiness.Income}" +
                      $"\nBalance:{dataBusiness.IncomeDelay}" +
                      $"\nBalance:{dataBusiness.Improvements}");
        }
        data.EndTime = DateTime.UtcNow;
        data.Balance = 200000;
        ServiceLocator.Instance.GetSingle<IConfigWriterService>().WriteConfig(data);
    }
}