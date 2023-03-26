using Services;

public interface IConfigWriterService : IService
{
    public void WriteConfig(BusinessData data);
}