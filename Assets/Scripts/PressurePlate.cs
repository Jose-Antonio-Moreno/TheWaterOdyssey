using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject doorOpen, doorClosed;
   

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" )
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);

        }
    }
}
