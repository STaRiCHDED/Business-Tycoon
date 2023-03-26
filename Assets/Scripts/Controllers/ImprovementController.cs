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
        private ImprovementModel _improvementModel;
        
        public void Initialize(ImprovementConfigModel improvementConfigModel)
        {
            _improvementView = GetComponent<ImprovementView>();
            _improvementModel = new ImprovementModel(improvementConfigModel);
            _improvementView.SetClickCallBack(BuyImprovement);
            _improvementView.Show(_improvementModel);
        }

        public void BuyImprovement()
        { 
            var improvementPrice = _improvementModel.Price;
            var balanceService= ServiceLocator.Instance.GetSingle<IBalanceService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            
            if (balanceService.HasEnoughMoney(improvementPrice))
            {
               _improvementModel.ChangeState(true);
               balanceService.Pay(improvementPrice);
              
               _improvementView.Show(_improvementModel);
            }
        }
    }
}