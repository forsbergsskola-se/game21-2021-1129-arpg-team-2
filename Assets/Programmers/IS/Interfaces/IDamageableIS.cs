public interface IDamageableIS
{
    public float CurrentHealth { get; set; }
    public void TakeDamage(FloatValue damage);
}
