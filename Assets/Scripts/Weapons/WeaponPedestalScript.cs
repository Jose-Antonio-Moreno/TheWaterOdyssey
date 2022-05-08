using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestalScript : MonoBehaviour
{
    public Weapons pedestalWeapon;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject[] weaponsSprite;
    GameObject weapon;

    //Sounds
    public AudioSource grabItem;

    private void Start()
    {
        int randomNumber = Random.Range(0,(int)Weapons.COUNT);
        pedestalWeapon = (Weapons)randomNumber;

        weaponsSprite[randomNumber].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        weaponsSprite[randomNumber].transform.localScale *= 0.5f;
        weaponsSprite[randomNumber].transform.Rotate(90f, 0f, 0f);
        Instantiate(weaponsSprite[randomNumber]);
       // weapon.transform.localScale = new Vector3(10f, 10f, 10f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabItem.Play();
        }
    }
        
}
