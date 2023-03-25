public interface IBalanceService : IService
{
    
    public void Pay(int amount);
    public void Receive(int amount);
    public bool HasEnoughMoney(int amount);
}