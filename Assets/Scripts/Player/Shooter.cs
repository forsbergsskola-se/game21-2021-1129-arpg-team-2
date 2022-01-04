using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObjectValue target;
    [SerializeField] private Vector3Value shootDirection;
    
    public void Shoot()
    {
        if (weapon.Ranged)
        {
            var temp = Instantiate(weapon.Projectile, transform.position, Quaternion.identity);
            shootDirection.Vector3 = (transform.position - target.Value.transform.position).normalized;
        }
        
    }
}
