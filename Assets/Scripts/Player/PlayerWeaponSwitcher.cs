using UnityEngine;

public class PlayerWeaponSwitcher : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private LevelUpChart playerLevelUpChart;

    [SerializeField] private int levelSecAtt;
    
    [Header("Weapons")]
    [SerializeField] private Weapon primary;
    [SerializeField] private Weapon secondary;
    [SerializeField] private Weapon current;

    private void Awake() => AssignWeapon(primary);
    
    private void Update() => SwitchWeapons();
    
    private void SwitchWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) AssignWeapon(primary);
        else if (Input.GetKeyDown(KeyCode.Alpha2) && playerLevelUpChart.CurrentLevel >= levelSecAtt) AssignWeapon(secondary);
    }

    private void AssignWeapon(Weapon weapon)
    {
        current.Name = weapon.Name;
        current.Power = weapon.Power;
        current.Range = weapon.Range;
        current.Ranged = weapon.Ranged;
        current.Projectile = weapon.Projectile;
    }
}
