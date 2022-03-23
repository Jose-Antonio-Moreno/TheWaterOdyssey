using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {


        SceneManager.LoadScene("MapaRespaldo");

    }

    public void Exit()
    {

        Application.Quit();

    }

    public void TutorialScene()
    {

        SceneManager.LoadScene("SceneTutorial");

    }
}
