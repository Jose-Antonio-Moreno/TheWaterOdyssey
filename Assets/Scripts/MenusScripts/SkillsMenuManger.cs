using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenuManger : MonoBehaviour
{
    public GameObject _inputManager;

    private GameObject player;
    private GameObject botones;

    private void Start()
    {
        PlayerControlls controller;
        controller = _inputManager.GetComponent<InputsController>().globalControls;
        player = GameObject.FindGameObjectWithTag("Player");
        controller.Gameplay.SetSkillSelectorPanel.started += ctx => setSkillMenuPanel();
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

    public void SelectPoison()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
    }
    public void SelectDoubleEdge()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.DOUBLEEDGE] = true;
    }
    public void SelectIce()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.ICE] = true;
    }
    public void SelectLightstep()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.LIGHTSTEP] = true;
    }
    public void SelectBouncy()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BOUNCY] = true;
    }
    public void SelectFireRate()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.FIRERATE] = true;
    }
    public void SelectShieldBubble()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.SHIELDBUBBLE] = true;
        Time.timeScale = 0.3f;

    }
    public void SelectBigBubble()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BIGBUBBLE] = true;
    }

}
