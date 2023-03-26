using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        private ImprovementView _improvementViewPrefab;

        [SerializeField]
        private RectTransform _improvementsSpawnRoot;

        private Action _onClicked;
    
        public void Show(BusinessConfigModel businessConfigModel)
        {
            _nameLabel.text = businessConfigModel.Name;
            _levelLabel.text = $"LVL {Convert.ToString(businessConfigModel.Level)}";
            _incomeLabel.text = $"Income\n{Convert.ToString(businessConfigModel.Income)}$";
            _upgradePriceLabel.text = $"LVL UP\nPrice {Convert.ToString(businessConfigModel.UpgradePrice)}$";

            foreach (var improvement in businessConfigModel.Improvements)
            {
                var businessImprovement = Instantiate(_improvementViewPrefab, _improvementsSpawnRoot);
                businessImprovement.Show(improvement);
            }
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