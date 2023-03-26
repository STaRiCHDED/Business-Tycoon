using Models;
using UnityEngine;

namespace Controllers
{
    public class BusinessesSpawner : MonoBehaviour
    {
        [SerializeField]
        private BusinessesConfig _businessesConfig;

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
            foreach (var businessModel in _businessesConfig.Businesses)
            {
                var business = Instantiate(_businessPrefab, _spawnRoot);
                business.Initialize(businessModel);
            }
        }
    }
}