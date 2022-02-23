using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Skill : MonoBehaviour, Skill_Interface
{
    Movement_2 player;
    bool isDashing = false;
    public float dashSpeed;
    bool canDash = true;
    float dashTime = 2;
    void Skill_Interface.ActivateSkill() 
    {
        if (dashTime <= 0)
        {
            canDash = true;
        }
        else
        {
            dashTime -= Time.deltaTime;
            canDash = false;
        }
    }
    void Dashing()
    {
        if (canDash)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(player.moveDirection * dashSpeed, ForceMode.Impulse);
            dashTime = 2;
        }
    }
}
