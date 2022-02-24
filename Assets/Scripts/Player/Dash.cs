using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private CharacterController controller;

    public float dashSpeed;
    Rigidbody rig;
    bool isDashing;
    float dashTime = 2;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (dashTime <= 0 )
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDashing = true;
                dashTime = 2;
            }
        }
        else { dashTime -= Time.deltaTime; }
    }
    void FixedUpdate()
    {
        if (isDashing) { Dashing(); }
    }
    // Update is called once per frame
    private void Dashing()
    {
        rig.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        isDashing = false;
    }
}
