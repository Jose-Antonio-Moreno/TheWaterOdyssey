using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public enum EAbilities {POISON, DOUBLEEDGE, ICE, LIGHTSTEP, DISCOUNT, DAMAGET, SLOWT, FIRERATE, BOUNCY, SHIELDBUBBLE, BIGBUBBLE, DUMMY};
    public Dictionary<EAbilities, bool> DSkills;
    
    
    void Awake()
    {
        DSkills = new Dictionary<EAbilities, bool>();

        EAbilities ability;

        for (int i = 0; i < (int)EAbilities.DUMMY; i++) 
        {
            ability = (EAbilities)i;
            DSkills.Add(ability, false);
        }
        DSkills[EAbilities.POISON] = true;
        DSkills[EAbilities.BOUNCY] = true;
        DSkills[EAbilities.LIGHTSTEP] = true;
        DSkills[EAbilities.FIRERATE] = true;
        DSkills[EAbilities.SHIELDBUBBLE] = true;
        DSkills[EAbilities.BIGBUBBLE] = true;
    }
}
