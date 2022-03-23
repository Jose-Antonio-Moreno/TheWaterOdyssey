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

    int random;

    void Start()
    {
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
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(weaponSpawn);
        }
    }
}
