using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Awake()
    {
        var serviceLocator = new ServiceLocator();
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService());
    }
}