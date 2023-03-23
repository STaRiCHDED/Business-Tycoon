using TMPro;
using UnityEngine;

public class ImprovementView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameLabel;
    
    [SerializeField]
    private TextMeshProUGUI _additionalPercentageIncomeLabel;
    
    [SerializeField]
    private TextMeshPro _stateLabel;

    private string _purchased = "Purchased";

    public void Show(ImprovementModel improvement)
    {
        _nameLabel.text = improvement.Name;
        _additionalPercentageIncomeLabel.text = "Income +" + improvement.AdditionalPercentageIncome + "%";
        _stateLabel.text = "Price" + improvement.Price;
    }
}