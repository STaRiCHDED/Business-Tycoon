using System;
using System.Collections.Generic;
using UnityEngine;

public class BusinessesSpawner : MonoBehaviour
{
    [SerializeField]
    private List<BusinessModel> _businesses;

    [SerializeField]
    private BusinessView _businessViewPrefab;

    [SerializeField]
    private RectTransform _spawnRoot;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var businessModel in _businesses)
        {
            var businessView = Instantiate(_businessViewPrefab, _spawnRoot);
            businessView.Initialize(businessModel);
        }
    }
}