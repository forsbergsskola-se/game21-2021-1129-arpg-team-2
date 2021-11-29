public interface IAttackIS
{
    public FloatValue Power { get; set; }
    public void Attack(IDamageableIS other);
}
