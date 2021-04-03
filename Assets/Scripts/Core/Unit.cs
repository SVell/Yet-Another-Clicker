using System;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 10;

        private Animator _animator;
        private int _goldDroppedOnDeath = 1;
        
        public int Health
        {
            get => health;
            set => health = value;
        }

        public int GoldDroppedOnDeath
        {
            set => _goldDroppedOnDeath = value;
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            _goldDroppedOnDeath = health / 10;
        }

        public void TakeDamage(int amount)
        {
            if (_animator != null)
            {
                _animator.SetTrigger("Hurt");

                health -= amount;

                if (health <= 0)
                {
                    Die();
                }
            }
            
        }

        public void Die()
        {
            _animator.SetBool("IsDead", true);
            GoldManager.OnIncreaseGold(_goldDroppedOnDeath);
            // Destroy(gameObject, 0.12f);
        }
    }
}
