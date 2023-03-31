using System.Collections.Generic;
using Controllers;
using Models;
using UnityEngine;

namespace Views
{
    public class BusinessesSpawner : MonoBehaviour
    {
        
        [SerializeField]
        private BusinessController _businessPrefab;
    
        [SerializeField]
        private RectTransform _spawnRoot;
        
        public void Spawn(IReadOnlyList<BusinessModel> businessModels)
        {
            foreach (var businessModel in businessModels)
            {
                var businessController = Instantiate(_businessPrefab, _spawnRoot);
                businessController.Initialize(businessModel);
            }
        }
    }
}