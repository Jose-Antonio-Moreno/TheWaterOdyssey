using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemies : MonoBehaviour
{
    public float counter =  0;

    public GameObject entradas;

    void Update()
    {
        if(counter <= 0) entradas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            entradas.SetActive(true);
        }
    }
}
