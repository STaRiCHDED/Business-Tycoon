using System;
using UnityEngine;

[Serializable]
public class ImprovementModel
{
    public string Name => _name;
   
    public int AdditionalPercentageIncome => _additionalPercentageIncome;

    public int Price => _price;

    public bool IsPurchased => _isPurchased;
   
    [SerializeField]
    private string _name;
   
    [SerializeField]
    private int _additionalPercentageIncome;

    [SerializeField]
    private int _price;

    [SerializeField]
    private bool _isPurchased;
}