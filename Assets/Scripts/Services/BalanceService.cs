using System;

namespace Services
{
    public class BalanceService : IBalanceService
    {
        public event Action<float> BalanceChanged;
        private readonly ConfigData _playerBalanceModel;

        public BalanceService(ConfigData playerBalanceModel)
        {
            _playerBalanceModel = playerBalanceModel;
        }

        public void Pay(int amount)
        {
            _playerBalanceModel.Balance -= amount;
            BalanceChanged?.Invoke(_playerBalanceModel.Balance);
        }

        public void Receive(int amount)
        {
            _playerBalanceModel.Balance += amount;
            BalanceChanged?.Invoke(_playerBalanceModel.Balance);
        }

        public bool HasEnoughMoney(int amount)
        {
            return _playerBalanceModel.Balance >= amount;
        }
    }
}