using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    Skill_Interface mySkillInterface;

    //Poison
    public bool isPoisonActivate;
    //Ice
    public bool isIceActivate;
    //Bouncy
    public bool isBouncyActivate;
    //Dash
    public bool isDashActivate;
    //Light Step
    public bool isLightStepActivate;
    //Discount
    public bool isDiscountActivate;
    //Double Edge
    public bool isDoubleEdgeActivate;
    //Slow Trail
    public bool isSlowTrailActivate;
    //Damaging Trail
    public bool isDamagingTrailActivate;
    //Fire Rate
    public bool isFireRateActivate;

    void Start()
    {
        isPoisonActivate = false;
        isIceActivate = false;
        isBouncyActivate = false;
        isDashActivate = false;
        isLightStepActivate = false;
        isDiscountActivate = false;
        isDoubleEdgeActivate = false;
        isSlowTrailActivate = false;
        isDamagingTrailActivate = false;
        isFireRateActivate = false;
    }
    void Update()
    {
        if (isLightStepActivate) 
        {

            isLightStepActivate = false;
        }
    }
}
