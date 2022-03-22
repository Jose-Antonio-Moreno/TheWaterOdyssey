using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenuManger : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SelectPoison()
    {
        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
        Debug.Log("POISON");
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
  
}
