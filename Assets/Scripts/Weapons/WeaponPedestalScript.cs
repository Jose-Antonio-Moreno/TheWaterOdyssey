using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestalScript : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject[] weaponsSprite;
    GameObject weapon;
    GameObject sprite;
    public int newWeaponNumber;
    //Sounds
    public AudioSource grabItem;

    private bool getItem = true;

    private void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        Weapons playerWeapon = player.GetComponent<Shooter>().weapon;
        
        do
        {
            newWeaponNumber = Random.Range(0, (int)Weapons.COUNT);
        } while (newWeaponNumber == (int)playerWeapon);

        weaponsSprite[newWeaponNumber].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        weaponsSprite[newWeaponNumber].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        sprite  = Instantiate(weaponsSprite[newWeaponNumber]);
       // weapon.transform.localScale = new Vector3(10f, 10f, 10f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (getItem)
            {
                grabItem.Play();
                getItem = false;
            }
            other.GetComponent<Shooter>().weapon = (Weapons)newWeaponNumber;
            Destroy(sprite);
            //Destroy(gameObject);
        }
    }
        
}
