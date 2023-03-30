using System;
using Models;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class ImprovementController : MonoBehaviour
    {
        public event Action ImprovementPurchased;
        
        [SerializeField]
        private ImprovementView _improvementView;
        
        private ImprovementModel _improvementModel;
        
        public void Initialize(ImprovementModel improvementModel)
        {
            _improvementModel = improvementModel;
            _improvementView.SetClickCallBack(BuyImprovement);
            UpdateView();
        }

        private void BuyImprovement()
        {
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            if (balanceService.HasEnoughMoney(_improvementModel.Price))
            {
                balanceService.Pay(_improvementModel.Price);
                _improvementModel.IsPurchased = true;
                ImprovementPurchased?.Invoke();
                UpdateView();
            }
        }

        private void UpdateView()
        {
            _improvementView.Show(_improvementModel);
        }
    }
}