public interface IDamageable
{
    public FloatValue CurrentHealth { get; set; }
    public void TakeDamage(FloatValue damage);
}
