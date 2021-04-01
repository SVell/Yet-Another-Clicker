using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 10;

        private int goldDroppedOnDeath;
        
        public int Health
        {
            get => health;
            set => health = value;
        }

        public int GoldDroppedOnDeath
        {
            set => goldDroppedOnDeath = value;
        }

        public void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Die()
        {
            GoldManager.OnIncreaseGold(goldDroppedOnDeath);
        }
    }
}
