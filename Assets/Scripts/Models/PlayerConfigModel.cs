using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "PlayerBalanceConfig", menuName = "PlayerBalanceConfig")]
    public class PlayerConfigModel : ScriptableObject
    {
        public PlayerBalanceModel PlayerBalanceModel => _playerBalanceModel;
    
        [SerializeField]
        private PlayerBalanceModel _playerBalanceModel;
    }
}