using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    [SerializeField] Transform player, checkpoint;
    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player")
        {
            player.transform.position = checkpoint.transform.position;
            
        }
    }
   
}
