public interface IDamageableIS
{
    public FloatVariableIS CurrentHealth { get; set; }
    public void TakeDamage(FloatVariableIS damage);
}
