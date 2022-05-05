using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestalScript : MonoBehaviour
{
    public Weapons pedestalWeapon;

    private void Start()
    {
        int randomNumber = Random.Range(0,(int)Weapons.COUNT);
        pedestalWeapon = (Weapons)randomNumber;
    }
}
