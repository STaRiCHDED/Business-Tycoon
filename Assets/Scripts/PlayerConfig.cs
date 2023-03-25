using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerBalanceConfig", menuName = "PlayerBalanceConfig")]
public class PlayerConfig : ScriptableObject
{
    public PlayerBalanceModel PlayerBalanceModel => _playerBalanceModel;
    
    [SerializeField]
    private PlayerBalanceModel _playerBalanceModel;
}