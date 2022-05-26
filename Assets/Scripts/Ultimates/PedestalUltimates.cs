using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalUltimates : MonoBehaviour
{
    [SerializeField]
    GameObject[] ultimate;
    GameObject ultimateSpawn;
    GameObject player;
    

    [SerializeField]
    ParticleSystem particles;

    bool getItem;
    int random;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject[] ultimatesImages;

    //Sounds
    public AudioSource grabItem;
    public GameObject Audio3D;

    void Start()
    {
        getItem = false;
        random = Random.Range(0, ultimate.Length);
        ultimate[random].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        ultimateSpawn = Instantiate(ultimate[random]);
        ultimateSpawn.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);//this.transform.localScale * 1.25f;
        player = GameObject.FindGameObjectWithTag("Player");
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
                Instantiate(particles, particles.transform.position, Quaternion.identity);
            }
            getItem = false;


            if (ultimateSpawn.CompareTag("BigDrop"))
            {
                grabItem.Play();
                Audio3D.SetActive(false);
                Instantiate(particles, particles.transform.position, Quaternion.identity);
                other.GetComponent<UltimateManager>().DUltimates[EUltimates.BIGDROP] = true;
                other.GetComponent<UltimateManager>().DUltimates[EUltimates.DROPINOMICON] = false;

            }
            
            if (ultimateSpawn.CompareTag("Dropinomicon"))
            {
                grabItem.Play();
                Audio3D.SetActive(false);
                Instantiate(particles, particles.transform.position, Quaternion.identity);
                other.GetComponent<UltimateManager>().DUltimates[EUltimates.BIGDROP] = false; 
                other.GetComponent<UltimateManager>().DUltimates[EUltimates.DROPINOMICON] = true;
            }
            
            Destroy(ultimateSpawn);
        }
    }
}
