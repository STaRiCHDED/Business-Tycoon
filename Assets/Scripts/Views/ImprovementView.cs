using System;
using JetBrains.Annotations;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ImprovementView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _nameLabel;
    
        [SerializeField]
        private TextMeshProUGUI _additionalPercentageIncomeLabel;
    
        [SerializeField]
        private TextMeshProUGUI _stateLabel;

        [SerializeField] 
        private Button _buyButton;
        
        private string _purchased = "Purchased";

        private Action _onClicked;

        [UsedImplicitly]
        public void SetClickCallBack(Action onClicked)
        {
            _onClicked = onClicked;
        }
        [UsedImplicitly]
        public void Click()
        {
            _onClicked?.Invoke();
        }
        public void Show(ImprovementModel improvementModel)
        {
            _nameLabel.text = improvementModel.Name;
            _additionalPercentageIncomeLabel.text = "Income +" + improvementModel.IncomeMultiplier + "%";
            _stateLabel.text = CheckPurchaseState(improvementModel);

        }
        private string CheckPurchaseState(ImprovementModel improvementModel)
        {
            if (improvementModel.IsPurchased)
            {
                _buyButton.interactable = false;
                return _purchased;
            }

            return "Price " + improvementModel.Price;
        }
        
    }
}