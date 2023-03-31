using System;
using Models;
using Services;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        [SerializeField]
        private BusinessView _businessView;

        [SerializeField]
        private IncomeController _incomeController;

        [SerializeField]
        private ImprovementController[] _improvementControllers;

        private BusinessModel _businessModel;
        private IBalanceService _balanceService;
        private IConfigService _configService;

        public void Initialize(BusinessModel businessModel)
        {
            _businessModel = businessModel;
            _balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
            _configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            
            _incomeController.Initialize(_businessModel);
            InitializeImprovements();

            _businessView.SetClickCallback(UpgradeLevel);

            UpdateView();
        }
        
        private void InitializeImprovements()
        {
            for (var i = 0; i < _improvementControllers.Length; i++)
            {
                var improvementModel = _businessModel.Improvements[i];
                var improvementController = _improvementControllers[i];
                improvementController.Initialize(improvementModel);
                improvementController.ImprovementPurchased += OnImprovementPurchased;
            }
        }

        private void OnImprovementPurchased()
        {
            _businessModel.CurrentIncome = _configService.RecalculateIncome(_businessModel);
            UpdateView();
        }

        private void UpgradeLevel()
        {
            if (_balanceService.HasEnoughMoney(_businessModel.CurrentUpgradePrice))
            {
                _balanceService.Pay(_businessModel.CurrentUpgradePrice);
                UpdateModel();
                UpdateView();
            }
        }
        
        private void UpdateModel()
        {
            _businessModel.CurrentLevel++;
            _businessModel.CurrentUpgradePrice = _configService.RecalculateUpgradePrice(_businessModel);
            _businessModel.CurrentIncome = _configService.RecalculateIncome(_businessModel);
        }

        private void UpdateView()
        {
            _businessView.Show(_businessModel);
        }

        private void OnDestroy()
        {
            foreach (var improvementController in _improvementControllers)
            {
                improvementController.ImprovementPurchased -= OnImprovementPurchased;
            }
        }
    }
}