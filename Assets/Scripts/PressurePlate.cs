using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject doorOpen, doorClosed, doorClosed1,doorClosed2;
    public AudioSource unlocked; // TEMPORAL
   

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" )
        {
            doorClosed.SetActive(false);
            doorClosed1.SetActive(false);
            doorClosed2.SetActive(false);
            doorOpen.SetActive(true);
            unlocked.Play();
        }
    }
}
