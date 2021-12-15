public interface IDamageable
{
    public CharStats CharStats { get; set; }
    public void TakeDamage(float damage);
}
