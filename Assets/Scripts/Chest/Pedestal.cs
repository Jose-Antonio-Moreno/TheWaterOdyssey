using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    [SerializeField]
    GameObject[] weapon;
    GameObject weaponSpawn;

    [SerializeField]
    ParticleSystem particles;

    bool getItem;
    int random;

    //Sounds
    public AudioSource grabItem;

    void Start()
    {
        getItem = false;
        random = Random.Range(0, weapon.Length);
        weapon[random].transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        weaponSpawn = Instantiate(weapon[random]);
        weaponSpawn.transform.localScale = this.transform.localScale * 1.25f;

    }
    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabItem.Play();
            if (getItem)Instantiate(particles, transform.position, Quaternion.identity);
            getItem = false;

           
            if(weaponSpawn.CompareTag("BigBubble")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BIGBUBBLE] = true;
            if(weaponSpawn.CompareTag("Bouncy")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BOUNCY] = true;
            if(weaponSpawn.CompareTag("FireRate")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.FIRERATE] = true;
            if(weaponSpawn.CompareTag("LightStep")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.LIGHTSTEP] = true;
            if(weaponSpawn.CompareTag("Poison")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
            if(weaponSpawn.CompareTag("ShieldTears")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.SHIELDBUBBLE] = true;


            Destroy(weaponSpawn);




        }
    }
}
