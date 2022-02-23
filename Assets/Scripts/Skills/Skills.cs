using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    //General Variables
    public Movement_2 player;
    public SkillManager skill;
    public LifeSystem life;
    public EnemyAI enemyN;
    public EnemyAIShell enemyS;


    //Poison
    float poisonTimer;
    float posionPerSecond;
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
        //Poison
        poisonTimer = 10;
        posionPerSecond = 1;
    }
    void Update()
    {        
        if (skill.isLightStepActivate)
        {
            Debug.Log(player.moveForce);
            ActivateLightStep();
            skill.isLightStepActivate = false;
        }
        if (skill.isPoisonActivate)
        {
            Debug.Log("Poison");
            //ActivatePoison();
        }
        if (skill.isIceActivate)
        {
            Debug.Log("Ice");
            //ActivateIce();
        }
        if (skill.isBouncyActivate)
        {
            Debug.Log("Bouncy");
            //ActivateBouncy();
        }
        if (skill.isDashActivate)
        {
            Debug.Log("Dash");
            //ActivateDash();
        }
        if (skill.isDiscountActivate)
        {
            Debug.Log("Discount");
            //ActivateDiscount();
        }
        if (skill.isDoubleEdgeActivate)
        {
            Debug.Log("Double Edge");
            ActivateDoubleEdge();
        }
        if (skill.isSlowTrailActivate)
        {
            Debug.Log("Slow Trail");
            //ActivateSlowTrail();
        }
        if (skill.isDamagingTrailActivate)
        {
            Debug.Log("Damaging Trail");
            //ActivateDamagingTrail();
        }
        if (skill.isFireRateActivate)
        {
            Debug.Log("Fire Rate");
            //ActivateFireRate();
        }
    }
    void ActivateLightStep()
    {
        player.moveForce = player.moveForce * 2;
    }
    void ActivatePoison()
    {
        if (enemyS.isHit) 
        {
            poisonTimer = 10;
            while (poisonTimer >= 0) 
            {
                if (posionPerSecond <= 0)
                {
                    enemyS.hp -= 0.2f;
                }
                else 
                {
                    posionPerSecond -= Time.deltaTime;
                }
                posionPerSecond = 1;
                poisonTimer--;
            }
        }
        if (enemyN.isHit)
        {
            poisonTimer = 10;
            while (poisonTimer >= 0)
            {
                if (posionPerSecond <= 0)
                {
                    enemyN.hp -= 0.2f;
                }
                else
                {
                    posionPerSecond -= Time.deltaTime;
                }
                posionPerSecond = 1;
                poisonTimer--;
            }
        }
    }
    //void ActivateIce()
    //{

    //}
    //void ActivateBouncy()
    //{

    //}
    //void ActivateDash()
    //{

    //}
    //void ActivateDiscount()
    //{

    //}
    void ActivateDoubleEdge() 
    {
        if(life.isDamaging)
        {
            enemyN.hp -= 1;
            enemyS.hp -= 1;
        }
    }
    //void ActivateSlowTrail()
    //{

    //}
    //void ActivateDamagingTrail()
    //{

    //}
    //void ActivateFireRate()
    //{

    //}

}
