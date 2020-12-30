using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIdx = 0;
    void Start()
    {
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeaponIdx = currentWeaponIdx;
        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeaponIdx != currentWeaponIdx)
        {
            SetActiveWeapon();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeaponIdx >= transform.childCount - 1)
            {
                currentWeaponIdx = 0;
            }
            else
            {
                currentWeaponIdx++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeaponIdx <= 0)
            {
                currentWeaponIdx = transform.childCount - 1;
            }
            else
            {
                currentWeaponIdx--;
            }
        }

    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIdx = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIdx = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIdx = 2;
        }

    }

    private void SetActiveWeapon()
    {
        int weaponIdx = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIdx == currentWeaponIdx)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIdx++;
        }
    }

}
