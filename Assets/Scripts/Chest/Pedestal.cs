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
    GameObject[] hudSkills;

    [SerializeField]
    Transform[] skillPositions;

    
    public sizePlayer aux;

    GameObject player;

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
            Debug.Log(aux.skillAux);
            
            if (getItem)
            {
                grabItem.Play();
                Audio3D.SetActive(false);
                Instantiate(particles, particles.transform.position, Quaternion.identity);
                getItem = false;
            }


            if (weaponSpawn.CompareTag("BigBubble"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.BIGBUBBLE] = true;
                
                hudSkills[1].SetActive(true);
                hudSkills[1].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;


            }
            if (weaponSpawn.CompareTag("Bouncy"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.BOUNCY] = true;
                
                hudSkills[2].SetActive(true);
                hudSkills[2].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;
            }
            if (weaponSpawn.CompareTag("FireRate"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.FIRERATE] = true;
                
                hudSkills[3].SetActive(true);
                hudSkills[3].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;
            }
            if (weaponSpawn.CompareTag("LightStep"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.LIGHTSTEP] = true;
                
                hudSkills[4].SetActive(true);
                hudSkills[4].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;
            }
            if (weaponSpawn.CompareTag("Poison"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.POISON] = true;
                
                hudSkills[5].SetActive(true);
                hudSkills[5].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;
            }
            if (weaponSpawn.CompareTag("ShieldTears"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.SHIELDBUBBLE] = true;
                
                hudSkills[0].SetActive(true);
                hudSkills[0].transform.position = skillPositions[aux.skillAux].transform.position;
                aux.skillAux++;
            }
            if (weaponSpawn.CompareTag("Ice"))
            {
                other.GetComponent<SkillManager>().DSkills[EAbilities.ICE] = true;
                
            }

            Destroy(weaponSpawn);
        }
    }
}
