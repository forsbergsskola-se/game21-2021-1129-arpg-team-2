using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObjectValue target;
    [SerializeField] private Vector3Value shootDirection;
    
    public void Shoot()
    {
        if (weapon.Ranged && target != null)
        {
            var temp = Instantiate(weapon.Projectile, transform.position, Quaternion.identity);
            shootDirection.Vector3 = (target.Value.transform.position - transform.position).normalized;
        }
    }
}
