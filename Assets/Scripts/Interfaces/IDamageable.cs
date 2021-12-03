public interface IDamageable
{
    public FloatValue CurrentHealth { get; set; }
    public void TakeDamage(float damage);
}
