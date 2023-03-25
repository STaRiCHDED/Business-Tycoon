
using System;
using TMPro;
using UnityEngine;

public class PlayerBalanceView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _balance;

    private void Awake()
    {
        var moneyService = ServiceLocator.Instance.GetSingle<BalanceService>();
        moneyService.BalanceChanged += ShowBalance;
    }

    public void ShowBalance(int balance)
    {
        _balance.text = "Balance" + balance + "$";
    }
}
