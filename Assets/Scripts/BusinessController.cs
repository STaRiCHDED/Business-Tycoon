using System;
using UnityEngine;

public class BusinessController : MonoBehaviour
{
    [SerializeField]
    private BusinessView _businessView;
    
    private BusinessModel _businessModel;

    public void Initialize(BusinessModel model)
    {
        _businessModel = model;
        _businessView.Show(_businessModel);
    }
}