using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject trophy;
    void Update()
    {
        if (enemies.Length <= 0) 
        {
            Instantiate(trophy, transform.position, Quaternion.identity);
        }   
    }
}
