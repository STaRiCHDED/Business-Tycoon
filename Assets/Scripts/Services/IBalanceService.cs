using System;
using Models;

namespace Services
{
    public interface IBalanceService : IService
    {
        public PlayerBalanceModel PlayerBalanceModel { get; set; }
        public event Action<float> BalanceChanged;
        public void Pay(float amount);
        public void Receive(float amount);
        public bool HasEnoughMoney(float amount);
        public void ResetBalance();
    }
}