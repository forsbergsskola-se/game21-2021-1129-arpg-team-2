using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;
    private int _totalWeapons = 1;
    void Start()
    {
        _totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[_totalWeapons];

        for (int i = 0; i < _totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;

    }

    void Update()
    {
        // Next Weapon
        if (Input.GetKey((KeyCode) 1))
        {
            if (currentWeaponIndex < _totalWeapons-1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapons[currentWeaponIndex].SetActive(true);
            }
            
        }
        // Previous weapon
        if (Input.GetKey((KeyCode) 2))
        {
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapons[currentWeaponIndex].SetActive(true);
            }
            
        }
      
    }
}
