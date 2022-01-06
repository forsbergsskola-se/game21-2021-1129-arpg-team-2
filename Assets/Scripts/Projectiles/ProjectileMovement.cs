using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private CharStats playerStats;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Vector3Value shootDirection;
    [SerializeField] private float speed;

    private void Update() => transform.position += shootDirection.Vector3 * speed * Time.deltaTime;
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.TakeDamage(weapon.Power * playerStats.AttackSpeed);
        Destroy(this.gameObject);
    }
}
