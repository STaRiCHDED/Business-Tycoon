using System.IO;
using Models;
using Newtonsoft.Json;
using UnityEngine.Device;

namespace Services
{
    public class FileService : IFileService
    {
        private const string _fileName = "/Saves.json";
        private readonly string _filePath;
        private readonly JsonSerializer _jsonSerializer;
        private readonly IConfigService _configService;

        public FileService(IConfigService configService)
        {
             _configService = configService;
             _filePath = Application.persistentDataPath + _fileName;
             _jsonSerializer = new JsonSerializer();
        }
        
        public void Save(SaveDataModel saveDataModel)
        {
            using var streamWriter = new StreamWriter(_filePath);
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            _jsonSerializer.Serialize(jsonWriter, saveDataModel);
        }

        public SaveDataModel Load()
        {
            if (File.Exists(_filePath))
            {
                using var streamReader = new StreamReader(_filePath);
                using JsonReader jsonReader = new JsonTextReader(streamReader);
                var saveDataModel = _jsonSerializer.Deserialize<SaveDataModel>(jsonReader);
                if (saveDataModel!=null)
                {
                    var playerBalanceModel = _configService.CreatePlayerBalanceModel(saveDataModel.PlayerBalanceModel.Balance);
                    var businessModels = _configService.GetBusinessModels(saveDataModel.BusinessModels);
                    var saveData = new SaveDataModel(playerBalanceModel, businessModels);
                    return saveData;
                }
            }

            var initialData = new SaveDataModel(_configService.CreatePlayerBalanceModel(0),
                _configService.GetBusinessModels());
            return initialData;
        }

        public void Delete()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}