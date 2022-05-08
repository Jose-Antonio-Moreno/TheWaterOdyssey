using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 == 4)
        {
            SceneManager.LoadScene(0);
        }
        if (other.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
