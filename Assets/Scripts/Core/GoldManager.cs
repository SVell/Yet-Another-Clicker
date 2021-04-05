using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
   public class GoldManager : MonoBehaviour
   {
      public static Action<int> OnIncreaseGold; 
      
      [SerializeField] private int currentGold;
      [SerializeField] private int goldPerTick = 1;

      private void OnEnable()
      {
         OnIncreaseGold += IncreaseGold;
      }

      private void OnDisable()
      {
         OnIncreaseGold -= IncreaseGold;
      }

      private void IncreaseGold(int amount)
      {
         currentGold += amount;
      }

      public void GoldTick(int multiplier = 1)
      {
         currentGold += goldPerTick * multiplier;
      }

      public int CurrentGold
      {
         get => currentGold;
         set => currentGold = value;
      }
   } 
}
