using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BalanceModel
{
    public string Balance => _balance;
    [SerializeField] private string _balance;
}