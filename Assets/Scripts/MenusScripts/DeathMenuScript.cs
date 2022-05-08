using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SingletonDataSaver.instance.RestartData();
        SceneManager.LoadScene(2);


    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }
}
