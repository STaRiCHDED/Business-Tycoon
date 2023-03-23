using System;
using System.Collections.Generic;
using UnityEngine;

public class BusinessesSpawner : MonoBehaviour
{
    [SerializeField]
    private BusinessesConfig _businessesConfig;
    
    [SerializeField]
    private BusinessView _businessViewPrefab;

    [SerializeField]
    private RectTransform _spawnRoot;

    private List<BusinessModel> _tempModels = new();

    public void Spawn()
    {
        foreach (var businessModel in _businessesConfig.Businesses)
        {
            var businessView = Instantiate(_businessViewPrefab, _spawnRoot);
            businessView.Initialize(businessModel);
            _tempModels.Add(businessModel);
        }
    }
}