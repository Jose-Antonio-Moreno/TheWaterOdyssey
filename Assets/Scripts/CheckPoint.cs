using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.lastCheckPoint = transform.position;
        }
    }
}
