using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BusinessesConfig", menuName = "BusinessesConfig")]
public class BusinessesConfig : ScriptableObject
{
    public IReadOnlyList<BusinessModel> Businesses => _businesses;
    
    [SerializeField]
    private List<BusinessModel> _businesses;
}