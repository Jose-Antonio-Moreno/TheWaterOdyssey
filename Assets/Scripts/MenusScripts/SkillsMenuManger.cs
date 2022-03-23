using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkillsMenuManger : MonoBehaviour
{
    public GameObject _inputManager;

    GameObject player;
    private GameObject botones;

    private void Start()
    {
        PlayerControlls controller;
        controller = _inputManager.GetComponent<InputsController>().globalControls;
        controller.Gameplay.Pause.started += ctx => setSkillMenuPanel();

        botones = gameObject.transform.GetChild(0).gameObject;


    }


        
    void setSkillMenuPanel()
    {
        if (botones.active == true)
        {
            botones.SetActive(false);
            Time.timeScale = 1f;

        }
        else if (botones.active == false)
        {
            botones.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void goMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goContinue()
    {
        Time.timeScale = 1f;
    }
    public void SelectPoison()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
        
    }
    public void SelectDoubleEdge()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.DOUBLEEDGE] = true;
    }
    public void SelectIce()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.ICE] = true;
    }
    public void SelectLightstep()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.LIGHTSTEP] = true;
    }
    public void SelectBouncy()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BOUNCY] = true;
    }
    public void SelectFireRate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.FIRERATE] = true;
    }
    public void SelectShieldBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.SHIELDBUBBLE] = true;

    }
    public void SelectBigBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BIGBUBBLE] = true;
    }

}
