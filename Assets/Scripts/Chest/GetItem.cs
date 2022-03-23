using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (this.CompareTag("BigBubble")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BIGBUBBLE] = true;
            if (this.CompareTag("Bouncy")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BOUNCY] = true;
            if (this.CompareTag("FireRate")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.FIRERATE] = true;
            if (this.CompareTag("LightStep")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.LIGHTSTEP] = true;
            if (this.CompareTag("Poison")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
            if (this.CompareTag("ShieldTears")) other.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.SHIELDBUBBLE] = true;

        }
    }
}
