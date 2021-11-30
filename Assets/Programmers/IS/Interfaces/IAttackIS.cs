public interface IAttackIS
{
    public FloatValue BasePower { get; set; }
    public void Attack(IDamageableIS thisTarget);
}
