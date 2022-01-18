using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    float jumpForce = 30;
    float maxVelocity = 8;
    bool canJump = true;
    bool airControll = false;

    float moveForce = 4;
    Vector2 stickDirection;
    Vector2 moveDirection;

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

        controls.Gameplay.Move.performed += ctx => stickDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => stickDirection = Vector2.zero;

    }

    void StopAirControll()
    {
        airControll = false;

    }
    void Jump()
    {
        gameObject.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0,300,0));
        airControll = true;
        Invoke("StopAirControll", 0.3f);


    }



    // Update is called once per frame
    void FixedUpdate()
    {

        //camera positioning
        float targerAngle = Mathf.Atan2(stickDirection.x, stickDirection.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
        moveDirection = Quaternion.Euler(0f, targerAngle, 0f) * gameObject.GetComponentInChildren<Transform>().forward;
        moveDirection = moveDirection.normalized;
        //Debug.Log(gameObject.GetComponentInChildren<Transform>().forward);


        gameObject.GetComponentInChildren<Rigidbody>().AddTorque(moveForce * moveDirection.y, 0, -moveForce * moveDirection.x);
        if (airControll)
        {
            gameObject.GetComponentInChildren<Rigidbody>().AddForce(0.3f * moveDirection.x, 0, 0.3f * moveDirection.y);

        }


        if (gameObject.GetComponentInChildren<Rigidbody>().velocity.x >= maxVelocity)
        {
            gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(maxVelocity, gameObject.GetComponentInChildren<Rigidbody>().velocity.y, gameObject.GetComponentInChildren<Rigidbody>().velocity.z);
        }

        if (gameObject.GetComponentInChildren<Rigidbody>().velocity.x <= -maxVelocity)
        {
            gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(-maxVelocity, gameObject.GetComponentInChildren<Rigidbody>().velocity.y, gameObject.GetComponentInChildren<Rigidbody>().velocity.z);
        }

        if (gameObject.GetComponentInChildren<Rigidbody>().velocity.z <= -maxVelocity)
        {
            gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(gameObject.GetComponentInChildren<Rigidbody>().velocity.x, gameObject.GetComponentInChildren<Rigidbody>().velocity.y, -maxVelocity);

        }
        if (gameObject.GetComponentInChildren<Rigidbody>().velocity.z >= maxVelocity)
        {
            gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(gameObject.GetComponentInChildren<Rigidbody>().velocity.x, gameObject.GetComponentInChildren<Rigidbody>().velocity.y, maxVelocity);

        }
        //if (gameObject.GetComponentInChildren<Rigidbody>().velocity.magnitude >= maxVelocity)
        //{
        //    gameObject.GetComponentInChildren<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponentInChildren<Rigidbody>().velocity, maxVelocity);
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
            canJump = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;

    }
}
