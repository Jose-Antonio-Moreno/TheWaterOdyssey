using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSetters : MonoBehaviour
{
    [SerializeField] public GameObject[] spawneable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            for (int i = 0; i <= spawneable.Length; i++) 
            {
                Debug.Log("SPAWWWWWWWWWWW");
                spawneable[i].SetActive(true);
            }
        }
    }
}
