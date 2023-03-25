using System;
using UnityEngine;

public class BusinessesSpawner : MonoBehaviour
{
    [SerializeField]
    private BusinessesConfigModel _businessesConfigModel;

    [SerializeField]
    private BusinessController _businessPrefab;
    
    [SerializeField]
    private RectTransform _spawnRoot;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var businessModel in _businessesConfigModel.Businesses)
        {
            var business = Instantiate(_businessPrefab, _spawnRoot);
            business.Initialize(businessModel);
        }
    }
}