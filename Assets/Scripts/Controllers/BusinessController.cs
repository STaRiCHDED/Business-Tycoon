using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        [SerializeField] private BusinessView _businessView;
        [SerializeField] private TimerController _timerController;
        public string Name => _businessData.Name;
        private BusinessData _businessData;
        private IConfigService _configService;
        
        public void Initialize(BusinessData configModel)
        {
            _configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            _businessView.SetClickCallback(LevelUp);
            _businessView.Initialize(configModel);
            _businessData = configModel;
            _timerController.Initialize(configModel);
            DisplayView();
        }
        
        public void UpdateBusinessData(BusinessData updatedData)
        {
            _businessData = updatedData; 
            DisplayView();
        }
        
        private void LevelUp()
        {
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();

            var price = _businessData.UpgradePrice;

            if (balanceService.HasEnoughMoney(price))
            {
                balanceService.Pay(price);
                UpdateLevel();
                UpdatePrice();
                UpdateIncome();
                DisplayView();
            }
        }

        private void DisplayView()
        {
            _businessView.Show(_businessData);
        }
        private void UpdateLevel()
        {
            _businessData.Level++;
        }
        private void UpdatePrice()
        {
            _configService.RecalculateUpgradePrice(_businessData.Level,_businessData.BasePrice);
        }

        private void UpdateIncome()
        {
            _configService.RecalculateIncome(_businessData.Level, _businessData.BaseIncome, _businessData.Improvements);
        }
    }
}