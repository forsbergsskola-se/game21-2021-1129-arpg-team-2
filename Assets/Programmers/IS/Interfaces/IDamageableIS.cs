public interface IDamageableIS
{
    public FloatVariableIS CurrentHealth { get; set; }
    public EntityStatus CurrentStatus { get; set; }
    public void TakeDamage(FloatVariableIS damage);
}
