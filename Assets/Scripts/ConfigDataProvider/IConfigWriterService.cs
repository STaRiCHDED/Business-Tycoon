using Services;

public interface IConfigWriterService : IService
{
    public void WriteConfig(ConfigData data);
}