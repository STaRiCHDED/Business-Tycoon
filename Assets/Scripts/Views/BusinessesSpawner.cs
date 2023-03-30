using Controllers;
using Models;
using UnityEngine;

namespace Views
{
    public class BusinessesSpawner : MonoBehaviour
    {
        [SerializeField]
        private BusinessesConfig _businessesConfig;

        [SerializeField]
        private BusinessController _businessPrefab;
    
        [SerializeField]
        private RectTransform _spawnRoot;
        
        public void Spawn()
        {
            foreach (var businessModel in _businessesConfig.Businesses)
            {
                var businessController = Instantiate(_businessPrefab, _spawnRoot);
                businessController.Initialize(businessModel);
            }
        }
    }
}