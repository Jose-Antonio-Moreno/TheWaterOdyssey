using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedestal : MonoBehaviour
{

    [SerializeField]
    GameObject[] weapon;
    GameObject weaponSpawn;
    

    [SerializeField]
    Image[] images;

    [SerializeField]
    ParticleSystem particles;

    bool getItem;
    int random;

    //Sounds
    public AudioSource grabItem;
    public GameObject Audio3D;

    void Start()
    {
        getItem = true;
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
            
            if (getItem)
            {
                grabItem.Play();
                Audio3D.SetActive(false);
                //Instantiate(particles, transform.position, Quaternion.identity);
                getItem = false;
            }


            if (weaponSpawn.CompareTag("BigBubble"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.BIGBUBBLE] = true;
                images[1].color = new Color(images[1].color.r, images[1].color.g, images[1].color.b, 0f);
            }
            if (weaponSpawn.CompareTag("Bouncy"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.BOUNCY] = true;
                images[2].color = new Color(images[2].color.r, images[2].color.g, images[2].color.b, 0f);
            }
            if (weaponSpawn.CompareTag("FireRate"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.FIRERATE] = true;
                images[3].color = new Color(images[3].color.r, images[3].color.g, images[3].color.b, 0f);
            }
            if (weaponSpawn.CompareTag("LightStep"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.LIGHTSTEP] = true;
                images[5].color = new Color(images[5].color.r, images[5].color.g, images[5].color.b, 0f);
            }
            if (weaponSpawn.CompareTag("Poison"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.POISON] = true;
                images[4].color = new Color(images[4].color.r, images[4].color.g, images[4].color.b, 0f);
            }
            if (weaponSpawn.CompareTag("ShieldTears"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.SHIELDBUBBLE] = true;
                images[0].color = new Color(images[0].color.r, images[0].color.g, images[0].color.b, 0f);
            }
            Destroy(weaponSpawn);
        }
    }
}
