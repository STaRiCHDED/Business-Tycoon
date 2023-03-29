using Services;
using TMPro;
using UnityEngine;

namespace Views
{
    public class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _balance;

        private void Start()
        {
            //var moneyService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            //moneyService.BalanceChanged += ShowBalance;
        }

        private void ShowBalance(float balance)
        {
            _balance.text = "Balance" + balance + "$";
        }
    
    }
}
