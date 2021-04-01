using System;
using UnityEngine;

namespace Core
{
   public class GoldManager : MonoBehaviour
   {
      public static Action<int> OnIncreaseGold; 
      
      [SerializeField] private int currentGold = 0;

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

      public int CurrentGold
      {
         get => currentGold;
         set => currentGold = value;
      }
   } 
}
