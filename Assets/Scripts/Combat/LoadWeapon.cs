using UnityEngine;

public class LoadWeapon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObject projectile;

    private void Awake()
    {
        if (weapon.Ranged) weapon.Projectile = projectile;
    }
}
