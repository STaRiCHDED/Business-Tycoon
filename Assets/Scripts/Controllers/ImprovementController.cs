using System;
using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class ImprovementController : MonoBehaviour
    {
        private ImprovementView _improvementView;
        private ImprovementData _improvementModel;
        
        public void Initialize(ImprovementData improvementData)
        {
            _improvementView = GetComponent<ImprovementView>();
            _improvementModel = improvementData;
            _improvementView.SetClickCallBack(BuyImprovement);
            //_improvementView.Show(_improvementModel);
        }

        private void BuyImprovement()
        { 
            var improvementPrice = _improvementModel.Price;
            var balanceService= ServiceLocator.Instance.GetSingle<IBalanceService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            
            if (balanceService.HasEnoughMoney(improvementPrice))
            {
               ChangeState(true);
               balanceService.Pay(improvementPrice);
              
               //_improvementView.Show(_improvementModel);
            }
        }
        public void ChangeState(bool isPurchased)
        {
            _improvementModel.IsPurchased = isPurchased;
        }
    }
}