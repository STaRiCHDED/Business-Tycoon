using Services;

public interface IConfigReaderService : IService
{
    public BusinessData ReadConfig();
}