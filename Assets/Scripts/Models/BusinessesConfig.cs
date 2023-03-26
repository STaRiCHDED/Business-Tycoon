using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "BusinessesConfig", menuName = "BusinessesConfig")]
    public class BusinessesConfig : ScriptableObject
    {
        public IReadOnlyList<BusinessConfigModel> Businesses => _businesses;
    
        [SerializeField]
        private List<BusinessConfigModel> _businesses;
    }
}