public interface IDamageableIS
{
    public FloatValue CurrentHealth { get; set; }
    public EntityStatus CurrentStatus { get; set; }
    public void TakeDamage(FloatValue damage);
}
