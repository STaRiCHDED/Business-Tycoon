using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class PlayerBalanceModel
    {
        public int Balance => _balance;
    
        [SerializeField]
        private int _balance;
    }
}