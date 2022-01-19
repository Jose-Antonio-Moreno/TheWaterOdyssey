using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class ButtonMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void startPlay()
    {
        SceneManager.LoadScene("MeadowDemo");
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
