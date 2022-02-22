using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool onGround;
    PlayerControlls controls;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPreassure;
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPreassure = 10f;
    }

    void Awake()
    {
        controls.Gameplay.Jump.performed += ctx => Salto();
    }
    // Update is called once per frame
    void Update()
    {
        //if (jumpPressure > 0f) 
        //{
        //    jumpPressure = jumpPressure + minJump;
        //    rbody.velocity = new Vector3(jumpPressure / 10f, jumpPressure, 0f);
        //    jumpPressure = 0f;
        //    onGround = false;
        //}         
    }

    void Salto()
    {
        if (onGround)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
            onGround = false;
            if (jumpPressure < maxJumpPreassure)
            {
                jumpPressure += Time.deltaTime * 10;
            }
            else 
            {
                jumpPressure = maxJumpPreassure;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            onGround = true;
        }
    }
}
