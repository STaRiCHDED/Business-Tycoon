using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerBalanceModel
{
    public int Balance => _balance;
    
    [SerializeField]
    private int _balance;
}