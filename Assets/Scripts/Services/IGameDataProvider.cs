using Models;

namespace Services
{
    public interface IGameDataProvider : IService
    {
        public SaveDataModel GetCurrentData();
    }
}