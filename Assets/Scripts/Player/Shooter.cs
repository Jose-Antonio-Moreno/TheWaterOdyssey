using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using DG.Tweening;
enum Weapons
{
    Basic,
    Auto,
    Shotgun,
    Triple,
    Sniper
}

public class Shooter : MonoBehaviour
{
    [SerializeField]
    Weapons weapon = Weapons.Sniper;
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

    float shotgunSpread = 0.4f; 
    int shotgunCartridges = 15;
    float shotgunDrag = 2;

    public ParticleSystem shootParticle;

    //Sounds
    public AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControlls controller;
        _inputManager = gameObject.GetComponent<Movement_2>().inputManager;
        controller = _inputManager.GetComponent<InputsController>().globalControls;

        controller.Gameplay.Shoot.started += ctx => ShootAutoTrue();
        controller.Gameplay.Ultimate.started += ctx => ShootBigDrop();
        controller.Gameplay.Shoot.canceled += ctx => ShootAutoFalse();
        controller.Gameplay.SwitchWeapon.started += ctx => SwitchWeapon();
        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }
    void SwitchWeapon()
    {
        if (weapon == Weapons.Basic)
            weapon = Weapons.Auto;
        else
            weapon = Weapons.Basic;
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
                fireRate = 7;
                break;
            case Weapons.Shotgun:
                fireRate = 1.5f;
                break;
            case Weapons.Triple:
                fireRate = 5;
                break;
            case Weapons.Sniper:
                fireRate = 1;
                break;
            default:
                fireRate = 3;
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
            if (weapon == Weapons.Basic || weapon == Weapons.Sniper || weapon == Weapons.Shotgun)
            {
                shooting = false;
            }
        }
        aimJoystick = _inputManager.GetComponent<InputsController>().rightStickDirection;

    }
    Vector3 aimDirection = new Vector3(1, 1, 1);

    void FixedUpdate()
    {
        if (aimJoystick.magnitude >= 0.1)
        {
            float angle = Mathf.Atan2(aimJoystick.x, aimJoystick.y) * Mathf.Rad2Deg + gameObject.GetComponent<Movement_2>().camera.eulerAngles.y;
            aimDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;

        }
        Vector3 v = gameObject.transform.position + aimDirection * 5;
        v.y = 0;
        pointer.transform.position = v;
    }

    public void Shake()
    {
        impulse.GenerateImpulse(0.25f);
    }
    public void Shake(float intensity)
    {
        impulse.GenerateImpulse(intensity);
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
        aimDirection.y = 0;
        GameObject aux;
        Vector3 shootForce;
        switch (weapon)
        {
            case Weapons.Basic:
                shoot.Play();
                Shake();
                aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x/100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                ParticleSystem a = Instantiate(shootParticle, gameObject.transform.position + aimDirection, Quaternion.identity);
                a.transform.LookAt(gameObject.transform.position + aimDirection);
                break;
            case Weapons.Auto:
                shoot.Play();
                Shake();
                aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 5;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                a = Instantiate(shootParticle, gameObject.transform.position + aimDirection*0.5f, Quaternion.identity);
                a.transform.LookAt(gameObject.transform.position + aimDirection);

                break;
            case Weapons.Shotgun:
                shoot.Play();
                Shake(1);
                for (int i = 0; i < shotgunCartridges; i++)
                {
                    Vector3 shotgunAimDirection = aimDirection;
                    shotgunAimDirection.x = aimDirection.x + Random.Range(-shotgunSpread, shotgunSpread);
                    shotgunAimDirection.z = aimDirection.z + Random.Range(-shotgunSpread, shotgunSpread);

                    aux = Instantiate(shootPrefab, gameObject.transform.position + shotgunAimDirection * 1.5f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                    aux.GetComponent<BulletScript>().damage = 10;
                    shootForce = shotgunAimDirection * 100;
                    aux.GetComponent<Rigidbody>().AddForce(shootForce*1.5f);
                    aux.GetComponent<Rigidbody>().drag = shotgunDrag;

                }
                break;
            case Weapons.Triple:
                shoot.Play();
                Shake(1);
                float angle = 15 * Mathf.Deg2Rad;
                //Right
                Vector3 tripleDirection = aimDirection;
                tripleDirection.x = aimDirection.x * Mathf.Cos(angle) - aimDirection.y * Mathf.Sin(angle);
                tripleDirection.z = aimDirection.z * Mathf.Sin(angle) + aimDirection.y * Mathf.Cos(angle);
                aux = Instantiate(shootPrefab, gameObject.transform.position + tripleDirection * 1.5f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = tripleDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                //Center
                tripleDirection = aimDirection;
                aux = Instantiate(shootPrefab, gameObject.transform.position + tripleDirection * 1.5f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = tripleDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                //Left
                tripleDirection = aimDirection;
                tripleDirection.x = aimDirection.x * Mathf.Cos(-angle) - aimDirection.y * Mathf.Sin(-angle);
                tripleDirection.z = aimDirection.z * Mathf.Sin(-angle) + aimDirection.y * Mathf.Cos(-angle);
                aux = Instantiate(shootPrefab, gameObject.transform.position + tripleDirection * 1.5f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = tripleDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                break;
            case Weapons.Sniper:
                shoot.Play();
                Shake();
                aux = Instantiate(shootPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 50;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce * 3);
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
