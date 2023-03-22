using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BusinessModel", fileName = "BusinessModel")]
public class BusinessModel : ScriptableObject
{
   public string Name => _name;
   
   public int Level => _level;
   
   public int Income => _income;

   public int UpgradePrice => _upgradePrice;

   public IReadOnlyList<Improvement> Improvements => _improvements;
   
   [SerializeField]
   private string _name;
   
   [SerializeField]
   private int  _level;
   
   [SerializeField]
   private int _income;

   [SerializeField]
   private int _upgradePrice;

   [SerializeField]
   private List<Improvement> _improvements;

}
