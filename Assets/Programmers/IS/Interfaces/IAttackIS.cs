public interface IAttackIS
{
    public FloatVariableIS BasePower { get; set; }
    public void Attack(IDamageableIS thisTarget);
}
