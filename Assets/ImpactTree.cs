using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactTree : MonoBehaviour
{
    //Sounds
    public AudioSource Impact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Impact.Play();
            
    }

}
