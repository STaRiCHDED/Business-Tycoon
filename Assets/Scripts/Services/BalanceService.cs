using System;

public class BalanceService : IBalanceService
{
    public event Action<int> BalanceChanged;
    private int _money;

    public void Pay(int amount)
    {
        if (HasEnoughMoney(amount))
        {
            _money -= amount;
            BalanceChanged?.Invoke(_money);
        }
    }

    public void Receive(int amount)
    {
        _money += amount;
        BalanceChanged?.Invoke(_money);
    }

    public bool HasEnoughMoney(int amount)
    {
        return _money >= amount;
    }
}