using System;

namespace Services
{
    public class BalanceService : IBalanceService
    {
        public event Action<float> BalanceChanged;
        private float _money = 1000;

        public void Pay(int amount)
        {
            _money -= amount;
            BalanceChanged?.Invoke(_money);
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
}