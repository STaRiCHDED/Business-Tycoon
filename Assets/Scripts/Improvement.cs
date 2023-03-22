using UnityEngine;

[CreateAssetMenu(menuName = "Improvement", fileName = "Improvement")]
public class Improvement : ScriptableObject
{
    public string Name => _name;
   
    public int AdditionalPercentageIncome => _additionalPercentageIncome;
   
    [SerializeField]
    private string _name;
   
    [SerializeField]
    private int _additionalPercentageIncome;
}