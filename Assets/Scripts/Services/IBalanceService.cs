﻿using System;
using Unity.VisualScripting;

public interface IBalanceService : IService
{
     event Action<int> BalanceChanged;
     void Pay(int amount);
     void Receive(int amount);
     bool HasEnoughMoney(int amount);
}