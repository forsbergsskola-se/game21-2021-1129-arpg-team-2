using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObjectValue target;
    [SerializeField] private Vector3Value shootDirection;

    private void Awake()
    {
        if (target == null)
        {
            target = ScriptableObject.CreateInstance<GameObjectValue>();
            target.Value = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Shoot()
    {
        if (weapon.Ranged && target != null)
        {
            Debug.Log(target.name);
            
            var temp = Instantiate(weapon.Projectile, transform.position, Quaternion.identity);
            shootDirection.Vector3 = (target.Value.transform.position - transform.position).normalized;
        }
    }
}
