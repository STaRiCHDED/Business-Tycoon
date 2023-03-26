using Models;
using TMPro;
using UnityEngine;

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

        private string _purchased = "Purchased";

        public void Show(ImprovementConfigModel improvementConfig)
        {
            _nameLabel.text = improvementConfig.Name;
            _additionalPercentageIncomeLabel.text = "Income +" + improvementConfig.IncomeMultiplier + "%";
            _stateLabel.text = $"Price- {improvementConfig.Price}$" ;
        }
    }
}