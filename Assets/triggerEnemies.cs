using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemies : MonoBehaviour
{
    public float counter = 0;

    public GameObject entradas;

    private bool drop = false;

    //Drops
    public GameObject healBubble;
    public GameObject coin;

    void Update()
    {
        if (counter <= 0) 
        { 
            entradas.SetActive(false);
            if (drop)
            {
                Drop();
                drop = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            drop = true;
            entradas.SetActive(true);
        }
    }
    private void Drop()
    {
        
        //Falta rotar la moneda
        int number = Random.RandomRange(0, 3);
        switch (number)
        {
            case 0:
                Instantiate(healBubble, transform.position, Quaternion.identity);
                break;
            case 1:
                //Instantiate(coin, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(healBubble, transform.position, Quaternion.identity);
                break;
        }
        
    }
}
