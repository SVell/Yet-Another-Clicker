namespace Core 
{
    public interface IDamageable
    {
        int Health { get; set; }
        void TakeDamage(int amount);
        void Die();
    }
}
