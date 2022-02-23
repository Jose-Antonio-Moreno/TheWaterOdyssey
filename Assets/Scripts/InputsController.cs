using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    public PlayerControlls globalControls;
    private CharacterController controller;

    //Variables
    [HideInInspector]
    public Vector2 leftStickDirection;

    [HideInInspector]
    public Vector2 rightStickDirection;


    private void OnEnable()
    {
        globalControls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        globalControls.Gameplay.Disable();

    }
    private void Awake()
    {
        globalControls = new PlayerControlls();
        globalControls.Gameplay.Move.performed += ctx => leftStickDirection = ctx.ReadValue<Vector2>();
        globalControls.Gameplay.Move.canceled += ctx => leftStickDirection = Vector2.zero;

        globalControls.Gameplay.Aim.performed += ctx => rightStickDirection = ctx.ReadValue<Vector2>();
        globalControls.Gameplay.Aim.canceled += ctx => rightStickDirection = Vector2.zero;



    }

    private void Start()
    {
        //controller = GetComponent<CharacterController>();

    }

}
