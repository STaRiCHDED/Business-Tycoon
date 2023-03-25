
using System;
using TMPro;
using UnityEngine;

public class PlayerBalanceView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _balance;

    private void Start()
    {
        var moneyService = ServiceLocator.Instance.GetSingle<IBalanceService>();
        moneyService.BalanceChanged += ShowBalance;
    }

    private void ShowBalance(int balance)
    {
        _balance.text = "Balance" + balance + "$";
    }
    
}
