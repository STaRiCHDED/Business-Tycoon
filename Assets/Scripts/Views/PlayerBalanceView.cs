using System;
using Services;
using TMPro;
using UnityEngine;

namespace Views
{
    public class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _balance;

        private IBalanceService _balanceService;

        private void Start()
        {
            _balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            _balanceService.BalanceChanged += ShowBalance;
        }

        private void ShowBalance(float balance)
        {
            _balance.text = "BALANCE: " + balance + "$";
        }

        private void OnDestroy()
        {
            _balanceService.BalanceChanged -= ShowBalance;
        }
    }
}
