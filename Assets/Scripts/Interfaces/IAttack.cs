public interface IAttack
{
    public FloatValue BasePower { get; set; }
    public void Attack(IDamageable thisTarget);
}
