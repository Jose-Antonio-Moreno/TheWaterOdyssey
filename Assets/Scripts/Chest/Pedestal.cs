using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    [SerializeField]
    GameObject[] weapon;
    GameObject weaponSpawn;
    GameObject player;

    [SerializeField]
    ParticleSystem particles;

    bool getItem;
    int random;

    //Sounds
    public AudioSource grabItem;

    void Start()
    {
        getItem = true;
        random = Random.Range(0, weapon.Length);
        weapon[random].transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        weaponSpawn = Instantiate(weapon[random]);
        weaponSpawn.transform.localScale = this.transform.localScale * 1.25f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
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
                Instantiate(particles, particles.transform.position, Quaternion.identity);
                getItem = false;
            }

           
            if(weaponSpawn.CompareTag("BigBubble")) other.GetComponent<SkillManager>().DSkills[EAbilities.BIGBUBBLE] = true;
            if(weaponSpawn.CompareTag("Bouncy")) other.GetComponent<SkillManager>().DSkills[EAbilities.BOUNCY] = true;
            if(weaponSpawn.CompareTag("FireRate")) other.GetComponent<SkillManager>().DSkills[EAbilities.FIRERATE] = true;
            if(weaponSpawn.CompareTag("LightStep")) other.GetComponent<SkillManager>().DSkills[EAbilities.LIGHTSTEP] = true;
            if(weaponSpawn.CompareTag("Poison")) other.GetComponent<SkillManager>().DSkills[EAbilities.POISON] = true;
            if(weaponSpawn.CompareTag("ShieldTears")) other.GetComponent<SkillManager>().DSkills[EAbilities.SHIELDBUBBLE] = true;
            Destroy(weaponSpawn);
        }
    }
}
