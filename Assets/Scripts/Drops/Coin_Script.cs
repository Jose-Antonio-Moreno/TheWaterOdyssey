using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //En un futuro añadirlo al contador de monedas del jugador.
            Invoke("Des", 0.1f);
        }
    }

    private void Des()
    {
        Destroy(this.gameObject);
    }
}
