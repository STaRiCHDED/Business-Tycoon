using System;
using TMPro;
using UnityEngine;

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
    private TextMeshProUGUI _firstImprovementLabel;
    
    [SerializeField]
    private TextMeshProUGUI _secondImprovementLabel;

    public void Initialize(string businessName, int level, int income, int upgradePrice,
        Improvement firstImprovement, Improvement secondImprovement)
    {
        _nameLabel.text = businessName;
        _levelLabel.text = $"LVL {Convert.ToString(level)}";
        _incomeLabel.text = $"Income\n{Convert.ToString(income)}$";
        _upgradePriceLabel.text = $"LVL UP\nPrice {Convert.ToString(upgradePrice)}$";
        _firstImprovementLabel.text = $"{firstImprovement.Name}\n" +
                                      $"Income - +{Convert.ToString(firstImprovement.AdditionalPercentageIncome)}%";
        _secondImprovementLabel.text = $"{secondImprovement.Name}\n" +
                                       $"Income - +{Convert.ToString(secondImprovement.AdditionalPercentageIncome)}%";
    }
}