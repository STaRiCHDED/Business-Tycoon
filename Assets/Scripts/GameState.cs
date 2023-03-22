using System;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private List<BusinessModel> _businesses;

    [SerializeField] 
    private RectTransform _spawnRoot;

    [SerializeField]
    private BusinessView _businessViewPrefab;

    private void Start()
    {
        foreach (var businessModel in _businesses)
        {
            var businessView = Instantiate(_businessViewPrefab, _spawnRoot);
            businessView.Initialize(businessModel.Name,businessModel.Level, businessModel.Income,
                businessModel.UpgradePrice,businessModel.Improvements[0],businessModel.Improvements[1]);
        }
    }
}