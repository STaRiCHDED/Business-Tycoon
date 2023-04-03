using System;
using Models;

namespace Services
{
    public class BalanceService : IBalanceService
    {
        public PlayerBalanceModel PlayerBalanceModel { get; set; }

        public event Action<float> BalanceChanged;

        public BalanceService(PlayerBalanceModel playerBalanceModel)
        {
            PlayerBalanceModel = playerBalanceModel;
        }

        public void Pay(float amount)
        {
            PlayerBalanceModel.Balance -= amount;
            BalanceChanged?.Invoke(PlayerBalanceModel.Balance);
        }

        public void Receive(float amount)
        {
            PlayerBalanceModel.Balance += amount;
            BalanceChanged?.Invoke(PlayerBalanceModel.Balance);
        }

        public bool HasEnoughMoney(float amount)
        {
            return PlayerBalanceModel.Balance >= amount;
        }

        public void ResetBalance()
        {
            PlayerBalanceModel.Balance = 0;
            BalanceChanged?.Invoke(PlayerBalanceModel.Balance);
        }
    }
}