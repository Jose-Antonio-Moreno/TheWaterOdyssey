using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource background;
    public AudioSource battle;

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("Enemy"))
        {
            background.Stop();
            battle.Play();
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        /*
        if (other.CompareTag("Enemy"))
        {
            background.Play();
            battle.Stop();
            Debug.Log("AAA");
        }
        */
    }
    private void OnTriggerStay(Collider other)
    {
        

    }
}
