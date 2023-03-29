using Services;

public interface IConfigReaderService : IService
{
    public ConfigData ReadConfig();
    public ConfigData ReadInstanceData();
}