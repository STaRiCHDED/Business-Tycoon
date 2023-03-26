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

        public void Show(ImprovementModel improvementModel)
        {
            _nameLabel.text = improvementModel.Name;
            _additionalPercentageIncomeLabel.text = "Income +" + improvementModel.IncomeMultiplier + "%";
            _stateLabel.text = "Price- " + improvementModel.Price;
        }
    }
}