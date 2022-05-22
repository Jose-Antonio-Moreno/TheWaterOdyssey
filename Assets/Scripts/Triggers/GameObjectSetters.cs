using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSetters : MonoBehaviour
{
    [SerializeField] public GameObject[] spawneable;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        {
            for (int i = 0; i <= spawneable.Length; i++) 
            {
                spawneable[i].SetActive(true);
            }
        }
    }
}
