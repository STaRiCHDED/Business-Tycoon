using System;
using System.Collections.Generic;
using Controllers;
using JetBrains.Annotations;
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

        [SerializeField]
        private ImprovementController _improvementPrefab;

        [SerializeField]
        private RectTransform _improvementsSpawnRoot;

        private Action _onClicked;

        public void Initialize(BusinessConfigModel configModel)
        {
            foreach (var improvement in configModel.Improvements)
            {
                var businessImprovement = Instantiate(_improvementPrefab, _improvementsSpawnRoot);
                businessImprovement.Initialize(improvement);
            }
        }
        public void Show(BusinessModel businessModel)
        {
            _nameLabel.text = businessModel.Name;
            _levelLabel.text = $"LVL {Convert.ToString(businessModel.CurrentLevel)}";
            _incomeLabel.text = $"Income\n{Convert.ToString(businessModel.CurrentIncome)}$";
            _upgradePriceLabel.text = $"LVL UP\nPrice {Convert.ToString(businessModel.CurrentUpgradePrice)}$";
        }
        
        [UsedImplicitly]
        // from LevelUpButton in Editor
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