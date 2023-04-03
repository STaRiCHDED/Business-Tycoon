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

        private List<BusinessController> _controllers = new();

        public void Spawn(IReadOnlyList<BusinessModel> businessModels)
        {
            foreach (var businessModel in businessModels)
            {
                var businessController = Instantiate(_businessPrefab, _spawnRoot);
                businessController.Initialize(businessModel);
                _controllers.Add(businessController);
            }
        }

        public void DeleteControllers()
        {
            if (_controllers.Count <= 0)
            {
                return;
            }

            foreach (var businessController in _controllers)
            {
                Destroy(businessController.gameObject);
            }
            _controllers.Clear();
        }
    }
}