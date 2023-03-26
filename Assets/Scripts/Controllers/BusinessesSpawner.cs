using System.Collections.Generic;
using Models;
using Services;
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
            var data = ServiceLocator.Instance.GetSingle<IConfigReaderService>().ReadConfig();
            Debug.Log($"Updating data:{data.EndTime}, Balance{data.Balance}");
            var saveData = new Dictionary<string, BusinessJson>();
            foreach (var dataBusiness in data.Businesses)
            {
                saveData.Add(dataBusiness.Name,dataBusiness);
            }
            foreach (var businessModel in _businessesConfig.Businesses)
            {
                var business = Instantiate(_businessPrefab, _spawnRoot);
                business.Initialize(businessModel);
                if (saveData.TryGetValue(business.Name, out var updatedData))
                {
                    business.UpdateBusinessData(updatedData);
                }
            }
        }
    }
}