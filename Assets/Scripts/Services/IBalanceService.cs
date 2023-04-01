using System;
using Models;

namespace Services
{
    public interface IBalanceService : IService
    {
        public float Balance { get; }
        public event Action<float> BalanceChanged;
        public void Pay(float amount);
        public void Receive(float amount);
        public bool HasEnoughMoney(float amount);
    }
}