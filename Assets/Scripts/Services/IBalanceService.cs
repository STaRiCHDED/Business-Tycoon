using System;

namespace Services
{
    public interface IBalanceService : IService
    {
        public event Action<float> BalanceChanged;
        public void Pay(float amount);
        public void Receive(float amount);
        public bool HasEnoughMoney(float amount);
    }
}