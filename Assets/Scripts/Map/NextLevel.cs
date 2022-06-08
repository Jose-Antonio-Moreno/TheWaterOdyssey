using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 == 5)
            {
                SceneManager.LoadScene(0); //Habr� que cambiarlo por cr�ditos
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
            
    }
}
