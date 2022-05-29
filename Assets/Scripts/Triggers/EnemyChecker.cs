using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject trophy;
    void Update()
    {
        Debug.Log(enemies.Length);
        if (enemies.Length <= 0) 
        {
            Instantiate(trophy, transform.position, Quaternion.identity);
        }   
    }
}
