using System;

namespace Models
{
    [Serializable]
    public class PlayerBalanceModel
    {
        public float Balance { get; set; }

        public PlayerBalanceModel(float balance)
        {
            Balance = balance;
        }
    }
}