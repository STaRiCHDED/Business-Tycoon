using System.Collections.Generic;
using Models;
using Services;
using UnityEngine;

namespace Controllers
{
    public class BusinessesSpawner : MonoBehaviour
    {
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
            var instanceData = ServiceLocator.Instance.GetSingle<IConfigReaderService>().ReadInstanceData();
            var saveData = ServiceLocator.Instance.GetSingle<IConfigReaderService>().ReadConfig();
            var saveDataDict = new Dictionary<string, BusinessData>();
            foreach (var dataBusiness in saveData.Businesses)
            {
                saveDataDict.Add(dataBusiness.Name,dataBusiness);
            }
            foreach (var businessModel in instanceData.Businesses)
            {
                var business = Instantiate(_businessPrefab, _spawnRoot);
                business.Initialize(businessModel);
                if (saveDataDict.TryGetValue(business.Name, out var updatedData))
                {
                    business.UpdateBusinessData(updatedData);
                }
            }
        }
    }
}