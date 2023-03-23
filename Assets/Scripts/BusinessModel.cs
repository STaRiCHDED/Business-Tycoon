using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BusinessModel
{
    public string Name => _name;
   
    public int Level => _level;
   
    public int Income => _income;

    public int IncomeDelay => _incomeDelay;

    public int UpgradePrice => _upgradePrice;

    public IReadOnlyList<ImprovementModel> Improvements => _improvements;
   
    [SerializeField]
    private string _name;
   
    [SerializeField]
    private int  _level;
   
    [SerializeField]
    private int _income;

    [SerializeField]
    private int _incomeDelay;

    [SerializeField]
    private int _upgradePrice;

    [SerializeField]
    private List<ImprovementModel> _improvements;

}