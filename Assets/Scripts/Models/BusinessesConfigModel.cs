using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BusinessesConfigModel", menuName = "BusinessesConfigModel")]
public class BusinessesConfigModel : ScriptableObject
{
    public IReadOnlyList<BusinessModel> Businesses => _businesses;
    
    [SerializeField]
    private List<BusinessModel> _businesses;
}