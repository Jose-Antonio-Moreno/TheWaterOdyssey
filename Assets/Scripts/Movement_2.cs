using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Movement_2 : MonoBehaviour
{

    private CharacterController controller;
    public GameObject shootPrefab;
    public Transform pointer;

    float gravity = 14.0f;
    float verticalVelocity;
    float maxVelocity = 1;
    bool canJump = true;
    bool airControll = false;
    public float moveForce = 30;
    Vector2 stickDirection;
    Vector3 moveDirection;

    Vector2 rightStickDirection;

    bool isDashing = false;
    public float dashSpeed;
    bool canDash = true;
    float dashTime = 2;

    public float jumpMultiplier;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPreassure;
    private bool jumpPressed;

    PlayerControlls controls;

    public Transform camera;


    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    GameObject aux;
    private void Awake()
    {

        controls = new PlayerControlls();

        controls.Gameplay.Jump.performed += ctx => Jump();
        //controls.Gameplay.Shoot.performed += ctx => Shoot();
        controls.Gameplay.Shoot.started += ctx => Shoot();
        controls.Gameplay.Dash.performed += ctx => Dashing();
        controls.Gameplay.Move.performed += ctx => stickDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => stickDirection = Vector2.zero;

        controls.Gameplay.Aim.performed += ctx => rightStickDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim.canceled += ctx => rightStickDirection = Vector2.zero;

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


        if (canJump)
        {
            if (jumpPressed)
            {
                Debug.Log("Im jumping");
                if (jumpPressure < maxJumpPreassure)
                {
                    jumpPressure += Time.deltaTime * jumpMultiplier;
                }
                else
                {
                    jumpPressure = maxJumpPreassure;
                }
            }
            jumpPressed = false;
            if (jumpPressure > 0f)
            {
                jumpPressure = jumpPressure + minJump;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpPressure, 0f)/* = new Vector3(jumpPressure / 10f, jumpPressure, 0f)*/;
                jumpPressure = 0f;
                canJump = false;
            }
        }

        
        
    }


    void StopAirControll()
    {
        airControll = false;
    }
    

 

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPreassure = 10f;
        jumpPressed = false;
    }
    Vector3 aimDirection;
    Vector3 shootVector;
    void Shoot()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0, camera.DOShakePosition(2f, 100f, 1000));
        GameObject aux =  Instantiate(shootPrefab, gameObject.transform.position + aimDirection*0.5f, Quaternion.identity);
        Vector3 shootForce = aimDirection * 100;
        aux.GetComponent<Rigidbody>().AddForce(shootForce);
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

        if (rightStickDirection.magnitude >= 0.1)
        {
            //camera positioning
            float angle = Mathf.Atan2(rightStickDirection.x, rightStickDirection.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            aimDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;
            //aimDirection = aimDirection.normalized;
        }
        Vector3 v = gameObject.transform.position + aimDirection * 5;
        pointer.transform.position = v;
        Debug.Log(aimDirection);



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


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    void Jump()
    {
        jumpPressed = true;
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
