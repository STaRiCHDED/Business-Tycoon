using Services;

public interface IConfigReaderService : IService
{
    public BusinessDataJson ReadConfig();
}