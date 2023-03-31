using System;
using Models;

namespace Services
{
    public class BalanceService : IBalanceService
    {
        public PlayerBalanceModel PlayerBalanceModel => _playerBalanceModel;
        public event Action<float> BalanceChanged;
        private readonly PlayerBalanceModel _playerBalanceModel;
        
        public BalanceService(PlayerBalanceModel playerBalanceModel)
        {
            _playerBalanceModel = playerBalanceModel;
        }
        
        public void Pay(float amount)
        {
            _playerBalanceModel.Balance -= amount;
            BalanceChanged?.Invoke(_playerBalanceModel.Balance);
        }

        public void Receive(float amount)
        {
            _playerBalanceModel.Balance += amount;
            BalanceChanged?.Invoke(_playerBalanceModel.Balance);
        }

        public bool HasEnoughMoney(float amount)
        {
            return _playerBalanceModel.Balance >= amount;
        }
    }
}