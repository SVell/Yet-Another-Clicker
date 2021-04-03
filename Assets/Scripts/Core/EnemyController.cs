using System;
using UnityEngine;

namespace Core
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemies;
        
        public Unit _currentEnemy;
        private int _enemyHealthMultiplier = 1;

        private void FixedUpdate()
        {
            if (_currentEnemy == null)
            {
                Debug.Log("Spawn");
                SpawnEnemy(enemies[0]);
            }
        }

        private void SpawnEnemy(GameObject enemyToSpawn)
        {
            _currentEnemy = Instantiate(enemyToSpawn).GetComponent<Unit>();
            _currentEnemy.Health *= _enemyHealthMultiplier;
        }

        public void ApplyDamageToUnit(int amount)
        {
            Debug.Log(amount);
            _currentEnemy.TakeDamage(amount);
        }
    }
}
