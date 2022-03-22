using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public enum EAbilities {POISON, DOUBLEEDGE, ICE, LIGHTSTEP, DISCOUNT, DAMAGET, SLOWT, FIRERATE, BOUNCY, SHIELDBUBBLE, BIGBUBBLE, DUMMY};
    public Dictionary<EAbilities, bool> DSkills;
    
    ////Poison
    //public bool isPoisonActivate;
    ////Ice
    //public bool isIceActivate;
    ////Bouncy
    //public bool isBouncyActivate;
    ////Dash
    //public bool isDashActivate;
    ////Light Step
    //public bool isLightStepActivate;
    ////Discount
    //public bool isDiscountActivate;
    ////Double Edge
    //public bool isDoubleEdgeActivate;
    ////Slow Trail
    //public bool isSlowTrailActivate;
    ////Damaging Trail
    //public bool isDamagingTrailActivate;
    ////Fire Rate
    //public bool isFireRateActivate;

    void Awake()
    {

        //isPoisonActivate = false;
        //isIceActivate = false;
        //isBouncyActivate = false;
        //isDashActivate = false;
        //isLightStepActivate = false;
        //isDiscountActivate = false;
        //isDoubleEdgeActivate = false;
        //isSlowTrailActivate = false;
        //isDamagingTrailActivate = false;
        //isFireRateActivate = false;

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
    void Update()
    {
        
    }
}
