public interface IDamageableIS
{
    public FloatValue CurrentHealth { get; set; }
    public void TakeDamage(float damage);
}
