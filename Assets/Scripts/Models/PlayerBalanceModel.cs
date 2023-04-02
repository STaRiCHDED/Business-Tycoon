using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class PlayerBalanceModel
    {
        public float Balance { get; set; }

        public PlayerBalanceModel(float balance = 0)
        {
            Balance = balance;
        }
    }
}