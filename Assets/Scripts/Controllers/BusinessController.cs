using System;
using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        private BusinessModel _businessModel;
        private BusinessView _businessView;
        
        public void Initialize(BusinessConfigModel configModel)
        {
            _businessView = GetComponent<BusinessView>();
            _businessView.SetClickCallback(LevelUp);
            _businessView.Initialize(configModel);
            
            _businessModel = new BusinessModel(configModel);
            DisplayView();
        }
        
        private void LevelUp()
        {
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();

            var price = _businessModel.CurrentUpgradePrice;

            if (balanceService.HasEnoughMoney(price))
            {
                balanceService.Pay(price);
                
                _businessModel.UpdateLevel();
                _businessModel.UpdatePrice();
                _businessModel.UpdateIncome();
                
                DisplayView();
            }
        }

        private void DisplayView()
        {
            _businessView.Show(_businessModel);
        }
    }
}