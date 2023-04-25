using System;
using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _nameLabel;

        [SerializeField]
        private TextMeshProUGUI _levelLabel;

        [SerializeField]
        private TextMeshProUGUI _incomeLabel;

        [SerializeField]
        private TextMeshProUGUI _upgradePriceLabel;

        private Action _onClicked;

        public void Show(BusinessModel businessModel)
        {
            _nameLabel.text = businessModel.Name;
            _levelLabel.text = "LVL" + businessModel.CurrentLevel;
            _incomeLabel.text = $"Income\n {businessModel.CurrentIncome.ToString()}";
            _upgradePriceLabel.text = "LVL UP\nPrice " + businessModel.CurrentUpgradePrice;
        }

        public void Click()
        {
            _onClicked?.Invoke();
        }

        public void SetClickCallback(Action onClicked)
        {
            _onClicked = onClicked;
        }
    }
}