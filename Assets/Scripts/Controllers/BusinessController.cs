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
                
                var newUpgradePrice = configService.RecalculateUpgradePrice(_businessModel.CurrentLevel, _businessModel.CurrentUpgradePrice);
                var newIncome = configService.RecalculateIncome(_businessModel.CurrentLevel, _businessModel.CurrentIncome,
                    _businessModel.Improvements[0].IncomeMultiplier,
                    _businessModel.Improvements[1].IncomeMultiplier);
                
                _businessModel.UpdatePrice(newUpgradePrice);
                _businessModel.UpdateIncome(newIncome);
                
                DisplayView();
            }
        }

        private void DisplayView()
        {
            _businessView.Show(_businessModel);
        }
    }
}