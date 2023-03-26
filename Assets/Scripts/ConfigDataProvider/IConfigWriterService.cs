using Services;

public interface IConfigWriterService : IService
{
    public void WriteConfig(BusinessDataJson dataJson);
}