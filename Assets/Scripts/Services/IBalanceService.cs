using System;

namespace Services
{
     public interface IBalanceService : IService
     {
          event Action<float> BalanceChanged;
          void Pay(int amount);
          void Receive(int amount);
          bool HasEnoughMoney(int amount);
     }
}