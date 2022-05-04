using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    void Play() {

       
        SceneManager.LoadScene("MapaRespaldo");
    
    }

    void Exit() {

        Application.Quit();

    }

    void TutorialScene() {

        SceneManager.LoadScene("SceneTutorial");
    
    }
}
