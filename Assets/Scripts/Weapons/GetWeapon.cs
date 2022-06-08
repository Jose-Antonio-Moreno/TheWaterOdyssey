using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    public Weapons pedestalWeapon;
    public Shooter variable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (pedestalWeapon == Weapons.Auto) 
            {
                variable.weapon = Weapons.Auto;
            }
            else if (pedestalWeapon == Weapons.Basic) 
            {
                variable.weapon = Weapons.Basic;
            }
            else if (pedestalWeapon == Weapons.Shotgun) 
            {
                variable.weapon = Weapons.Shotgun;
            }
            else if (pedestalWeapon == Weapons.Sniper) 
            {
                variable.weapon = Weapons.Sniper;
            }
        }
    }
}


