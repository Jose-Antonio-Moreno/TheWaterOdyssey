using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2 : MonoBehaviour
{

    private CharacterController controller;

    float gravity = 14.0f;
    public float jumpForce = 30;
    float verticalVelocity;
    float maxVelocity = 8;
    bool canJump = true;
    bool airControll = false;

    public float moveForce = 20;
    Vector2 stickDirection;
    Vector3 moveDirection;

    bool isDashing = false;
    public float dashSpeed;
    bool canDash = true;
    float dashTime = 2;

    PlayerControlls controls;

    public Transform camera;

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void Awake()
    {
        controls = new PlayerControlls();

        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Dash.performed += ctx => Dashing();
        controls.Gameplay.Move.performed += ctx => stickDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => stickDirection = Vector2.zero;

    }

    void Update()
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
    void StopAirControll()
    {
        airControll = false;
    }
    void Jump()
    {
        if (canJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
            airControll = true;
            Invoke("StopAirControll", 0.3f);
            canJump = false;
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (stickDirection.magnitude >= 0.1)
        {
            //camera positioning
            float targerAngle = Mathf.Atan2(stickDirection.x, stickDirection.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            moveDirection = Quaternion.Euler(0.0f, targerAngle, 0.0f) * Vector3.forward;
            moveDirection = moveDirection.normalized;
            gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
             

        //if (airControll)
        //{
        //    gameObject.GetComponent<Rigidbody>().AddForce(0.3f * moveDirection.x, 0, 0.3f * moveDirection.y);

        //}


        if (gameObject.GetComponent<Rigidbody>().velocity.x >= maxVelocity)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(maxVelocity, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if (gameObject.GetComponent<Rigidbody>().velocity.x <= -maxVelocity)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-maxVelocity, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
        }

        if (gameObject.GetComponent<Rigidbody>().velocity.z <= -maxVelocity)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, -maxVelocity);

        }
        if (gameObject.GetComponent<Rigidbody>().velocity.z >= maxVelocity)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, maxVelocity);

        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    canJump = true;

    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    canJump = false;

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            canJump = true;
        }
        else {
            canJump = false;
        }
    }

    void Dashing()
    {
        if (canDash) 
        {
            gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * dashSpeed, ForceMode.Impulse);
            dashTime = 2;
        }
    }
}
