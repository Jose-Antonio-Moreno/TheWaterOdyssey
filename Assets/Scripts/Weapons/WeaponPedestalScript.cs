using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestalScript : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;
    Transform player;

    [SerializeField]
    GameObject[] weaponsSprite;
    GameObject weapon;
    GameObject sprite;
   
    public int newWeaponNumber;

    [SerializeField]
    ParticleSystem particles;
    //Sounds
    public AudioSource grabItem;
    public GameObject Audio3D;

    private bool getItem = true;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

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
    private void Update()
    {
        particles.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (getItem)
            {
                grabItem.Play();
                Audio3D.SetActive(false);
                Instantiate(particles, particles.transform.position, Quaternion.identity);
                getItem = false;
            }
            other.GetComponent<Shooter>().weapon = (Weapons)newWeaponNumber;
            Destroy(sprite);
            //Destroy(gameObject);
        }
    }
        
}
