using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBubble_Script : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Hacer que le sume uno de vida al jugador
            Invoke("Des", 0.1f);
        }
    }

    private void Des()
    {
        Destroy(this.gameObject);
    }
}
