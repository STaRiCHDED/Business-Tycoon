using Models;
using Services;
using UnityEngine;
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

        public void Initialize(BusinessModel businessModel)
        {
            _businessModel = businessModel;

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
            _incomeController.ResetProgressBar();
            UpdateModel(true);
            UpdateView();
        }

        private void UpgradeLevel()
        {
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();

            if (balanceService.HasEnoughMoney(_businessModel.CurrentUpgradePrice))
            {
                balanceService.Pay(_businessModel.CurrentUpgradePrice);
                _incomeController.ResetProgressBar();
                UpdateModel(false);
                UpdateView();
            }
        }

        private void UpdateModel(bool isImprovement)
        {
            var recalculationService = ServiceLocator.Instance.GetSingle<IRecalculationService>();

            if (isImprovement)
            {
                _businessModel.CurrentIncome = recalculationService.RecalculateIncome(_businessModel);
                return;
            }

            _businessModel.CurrentLevel++;
            _businessModel.CurrentUpgradePrice = recalculationService.RecalculateUpgradeLevelPrice(_businessModel);
            _businessModel.CurrentIncome = recalculationService.RecalculateIncome(_businessModel);
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