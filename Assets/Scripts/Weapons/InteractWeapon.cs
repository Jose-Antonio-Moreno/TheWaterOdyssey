using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWeapon : MonoBehaviour
{
    [SerializeField]
    ParticleSystem spawnParticles;
    void Start() 
    {
        spawnParticles.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ParticleSystem x = Instantiate(spawnParticles);
        x.transform.localScale = this.transform.localScale / 200;
    }
    void Update() 
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
        }
    }
}
