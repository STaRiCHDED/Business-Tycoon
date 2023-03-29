using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        public string Name => BusinessData.Name;
        public BusinessData BusinessData { get; private set; }
        private BusinessView _businessView;
        private IConfigService _configService;
        
        public void Initialize(BusinessData configModel)
        {
            _configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            _businessView = GetComponent<BusinessView>();
            _businessView.SetClickCallback(LevelUp);
            _businessView.Initialize(configModel);
            BusinessData = configModel;
            DisplayView();
        }
        
        public void UpdateBusinessData(BusinessData updatedData)
        {
            BusinessData = updatedData; 
            DisplayView();
        }
        
        private void LevelUp()
        {
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();

            var price = BusinessData.UpgradePrice;

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
            _businessView.Show(BusinessData);
        }
        private void UpdateLevel()
        {
            BusinessData.Level++;
        }
        private void UpdatePrice()
        {
            _configService.RecalculateUpgradePrice(BusinessData.Level,BusinessData.BasePrice);
        }

        private void UpdateIncome()
        {
            _configService.RecalculateIncome(BusinessData.Level, BusinessData.BaseIncome, BusinessData.Improvements);
        }
    }
}