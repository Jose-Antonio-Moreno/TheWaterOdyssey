using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "OnboardingScene")
        {
            SceneManager.LoadScene("OnboardingScene");
            return;
        }
        else
        {
            SingletonDataSaver.instance.RestartData();
            SceneManager.LoadScene("LEVEL_1");
        }


    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }
}
