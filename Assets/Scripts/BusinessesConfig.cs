using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Businesses", menuName = "Businesses")]
public class BusinessesConfig : ScriptableObject
{
    public IReadOnlyList<BusinessModel> Businesses => _businesses;
    
    [SerializeField]
    private List<BusinessModel> _businesses;
}
