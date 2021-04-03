using UnityEngine;

namespace Core 
{
    [RequireComponent(typeof(EnemyController), typeof(GoldManager))]
    public class Clicker : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int damageMultiplier = 1;

        private EnemyController _enemyController;

        private void Awake()
        {
            _enemyController = GetComponent<EnemyController>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoDamage();
            }
        }

        private void DoDamage()
        {
            _enemyController.ApplyDamageToUnit(GetDamage());
        }

        private int GetDamage()
        {
            return damage * damageMultiplier;
        }
    }
}
