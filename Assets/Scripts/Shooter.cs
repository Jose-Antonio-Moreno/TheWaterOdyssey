using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using DG.Tweening;
enum Weapons
{
    Basic,
    Auto
}
public class Shooter : MonoBehaviour
{
    Weapons weapon = Weapons.Basic;
    CinemachineImpulseSource impulse;
    GameObject _inputManager;
    Vector2 aimJoystick;
    public GameObject shootPrefab;

    public Transform pointer;

    bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControlls controller;
        _inputManager = gameObject.GetComponent<Movement_2>().inputManager;
        controller = _inputManager.GetComponent<InputsController>().globalControls;

        controller.Gameplay.Shoot.started += ctx => ShootAutoTrue();
        controller.Gameplay.Shoot.canceled += ctx => ShootAutoFalse();
        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }

    float nextShoot = 0;
    public float fireRate;
    private void Update()
    {
        //SetFireRate
        switch (weapon)
        {
            case Weapons.Basic:
                fireRate = 4;
                break;
            case Weapons.Auto:
                fireRate = 6;
                break;
            default:
                break;
        }


        if (shooting && Time.time >= nextShoot)
        {
            nextShoot = Time.time + 1f / fireRate;
            Shoot();
            if (weapon == Weapons.Basic)
            {
                shooting = false;
            }
        }
        aimJoystick = _inputManager.GetComponent<InputsController>().rightStickDirection;

    }
    Vector3 aimDirection;

    void FixedUpdate()
    {
        if (aimJoystick.magnitude >= 0.1)
        {
            float angle = Mathf.Atan2(aimJoystick.x, aimJoystick.y) * Mathf.Rad2Deg + gameObject.GetComponent<Movement_2>().camera.eulerAngles.y;
            aimDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;

        }
        Vector3 v = gameObject.transform.position + aimDirection * 5;
        pointer.transform.position = v;
    }

    public void Shake()
    {
        impulse.GenerateImpulse(0.25f);
    }

    void ShootAutoFalse()
    {
        shooting = false;
        
    }
    void ShootAutoTrue()
    {
        shooting = true;

    }

    void Shoot()
    {
        switch (weapon)
        {
            case Weapons.Basic:
            case Weapons.Auto:
                Shake();
                GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 0.5f, Quaternion.identity);
                Vector3 shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                break;
            default:
                break;
        }
    }
}
