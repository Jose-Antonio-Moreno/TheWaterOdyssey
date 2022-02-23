using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEdge_Skill : MonoBehaviour, Skill_Interface
{
    LifeSystem life;
    void Skill_Interface.ActivateSkill() 
    {
        if (life.isDamaging) 
        {
            //Deal Damage Enemy
        }
    }
}
