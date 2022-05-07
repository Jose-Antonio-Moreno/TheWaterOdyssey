using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalUltimates : MonoBehaviour
{
    [SerializeField]
    GameObject[] ultimate;
    GameObject ultimateSpawn;

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

    void Start()
    {
        getItem = false;
        random = Random.Range(0, ultimate.Length);
        ultimate[random].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        ultimateSpawn = Instantiate(ultimate[random]);
        ultimateSpawn.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);//this.transform.localScale * 1.25f;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //grabItem.Play();
            if (getItem) Instantiate(particles, transform.position, Quaternion.identity);
            getItem = false;


            if (ultimateSpawn.CompareTag("BigDrop"))
            {
                other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = true;
                other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = false;

            }
            
            if (ultimateSpawn.CompareTag("Dropinomicon"))
            {
                other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = false; 
                other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = true;
            }
            
            Destroy(ultimateSpawn);
        }
    }
}
