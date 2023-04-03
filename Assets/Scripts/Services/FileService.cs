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

        public FileService()
        {
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
                return saveDataModel;
            }

            return null;
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