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

        [SerializeField]
        private ImprovementView _improvementViewPrefab;

        [SerializeField]
        private RectTransform _improvementsSpawnRoot;
    
        public void Show(BusinessModel businessModel)
        {
            _nameLabel.text = businessModel.Name;
            _levelLabel.text = $"LVL {Convert.ToString(businessModel.Level)}";
            _incomeLabel.text = $"Income\n{Convert.ToString(businessModel.Income)}$";
            _upgradePriceLabel.text = $"LVL UP\nPrice {Convert.ToString(businessModel.UpgradePrice)}$";

            foreach (var improvement in businessModel.Improvements)
            {
                var businessImprovement = Instantiate(_improvementViewPrefab, _improvementsSpawnRoot);
                businessImprovement.Show(improvement);
            }
        }
    }
}