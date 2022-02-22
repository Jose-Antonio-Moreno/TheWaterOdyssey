using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    //General Variables
    public Movement_2 player;
    public SkillManager skill;

    //Poison

    //Ice

    //Bouncy

    //Dash

    //Light Step

    //Discount

    //Double Edge

    //Slow Trail

    //Damaging Trail

    //Fire rate

    void Start()
    {

    }
    void Update()
    {

        if (skill.isLightStepActivate) 
        {
            ActivateLightStep();
            Debug.Log(player.moveForce);
            skill.isLightStepActivate = false;
        }
        if (skill.isPoisonActivate) 
        {
            Debug.Log("Poison");
            ActivatePoison();
        }
        if (skill.isIceActivate) 
        {
            Debug.Log("Ice");
            ActivateIce();
        }
        if (skill.isBouncyActivate) 
        {
            Debug.Log("Bouncy");
            ActivateBouncy();
        }
        if (skill.isDashActivate) 
        {
            Debug.Log("Dash");
            ActivateDash();
        }
        if (skill.isDiscountActivate) 
        {
            Debug.Log("Discount");
            ActivateDiscount();
        }
        if (skill.isDoubleEdgeActivate) 
        {
            Debug.Log("Double Edge");
            ActivateDoubleEdge();
        }
        if (skill.isSlowTrailActivate) 
        {
            Debug.Log("Slow Trail");
            ActivateSlowTrail();
        }
        if (skill.isDamagingTrailActivate) 
        {
            Debug.Log("Damaging Trail");
            ActivateDamagingTrail();
        }
        if (skill.isFireRateActivate) 
        {
            Debug.Log("Fire Rate");
            ActivateFireRate();
        }
    }
    void ActivateLightStep() 
    {
        player.moveForce = player.moveForce * 2;
    }
    void ActivatePoison()
    {

    }
    void ActivateIce()
    {

    }
    void ActivateBouncy()
    {

    }
    void ActivateDash()
    {

    }
    void ActivateDiscount()
    {

    }
    void ActivateDoubleEdge() 
    {

    }
    void ActivateSlowTrail()
    {

    }
    void ActivateDamagingTrail()
    {

    }
    void ActivateFireRate()
    {

    }

}
