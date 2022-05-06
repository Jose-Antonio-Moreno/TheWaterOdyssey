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

    //Sounds
    public AudioSource grabItem;

    void Start()
    {
        getItem = false;
        random = Random.Range(0, ultimate.Length);
        ultimate[random].transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        ultimateSpawn = Instantiate(ultimate[random]);
        ultimateSpawn.transform.localScale = this.transform.localScale * 1.25f;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabItem.Play();
            if (getItem) Instantiate(particles, transform.position, Quaternion.identity);
            getItem = false;


            if (ultimateSpawn.CompareTag("BigDrop")) other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = true;
            else { other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = false; }
            if (ultimateSpawn.CompareTag("Dropinomicon")) other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = true;
            else { other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = false; }
            Destroy(ultimateSpawn);
        }
    }
}
