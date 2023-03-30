using Models;

namespace Services
{
    public interface IFileService : IService
    {
        public void Save(SaveDataModel saveDataModel);
        public SaveDataModel Load();
        public void Delete();
    }
}