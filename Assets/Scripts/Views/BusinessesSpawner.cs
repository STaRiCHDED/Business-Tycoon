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
            var newData = UpdateData(instanceData, saveData);
            foreach (var businessModel in newData.Businesses)
            {
                var business = Instantiate(_businessPrefab, _spawnRoot);
                business.Initialize(businessModel);
            }
            foreach (var businessModel in newData.Businesses)
            {
                var str = "";
                str += $"Name {businessModel.Name}\n";
                str += $"Income {businessModel.Level}\n";
                foreach (var businessDataImprovement in businessModel.Improvements)
                {
                    str += $"Imp {businessDataImprovement.Name}  isPurchased {businessDataImprovement.IsPurchased} ";
                }
                Debug.Log(str);
            }
        }

        private ConfigData UpdateData(ConfigData instanceData,ConfigData saveData)
        {
            var saveDataDict = new Dictionary<string, BusinessData>();
            foreach (var dataBusiness in saveData.Businesses)
            {
                saveDataDict.Add(dataBusiness.Name,dataBusiness);
            }
            for (var index = 0; index < instanceData.Businesses.Count; index++)
            {
                if (saveDataDict.TryGetValue(instanceData.Businesses[index].Name, out var updatedData))
                {
                    instanceData.Businesses[index] = updatedData;
                }
            }
            return instanceData;
        }
    }
}