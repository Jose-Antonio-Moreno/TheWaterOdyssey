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
    Weapons weapon = Weapons.Auto;
    CinemachineImpulseSource impulse;
    GameObject _inputManager;
    Vector2 aimJoystick;
    public GameObject shootPrefab;
    
    [SerializeField]
    GameObject bigDropPrefab;

    [SerializeField]
    sizePlayer life;

    public Transform pointer;

    bool shooting = false;

    bool hasAbility;

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
        if (Input.GetKeyDown("space")) {
            ShootBigDrop();


        }
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
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.FIRERATE, out hasAbility);
            
            if (hasAbility)
            {
                fireRate *= 1.5f;
            }
            
            Debug.Log(fireRate);
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

    public void ShakeUltimate() {

        impulse.GenerateImpulse(0.55f);
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
        GameObject aux;
        Vector3 shootForce;
        switch (weapon)
        {
            case Weapons.Basic:
                Shake();
                aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x/100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                break;
            case Weapons.Auto:
                Shake();
                aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 5;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                break;
            default:
                break;
        }
    }


    void ShootBigDrop() {

        GameObject aux;
        Vector3 shootForce;

        if (life.life > 1)
        {
            ShakeUltimate();
            life.life -= 1;
            life.changed = false;
            aux = Instantiate(bigDropPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
            aux.GetComponent<BulletScript>().damage = 100;
            shootForce = aimDirection * 100;
            aux.GetComponent<Rigidbody>().AddForce(shootForce);
        
        }

    }

}
