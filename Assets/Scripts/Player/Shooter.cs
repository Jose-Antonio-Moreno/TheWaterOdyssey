using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum Weapons
{
    Auto = 0,
    Shotgun = 1,
    Sniper = 2,
    Spray = 3,
    COUNT,
    Basic,
    Triple
}

public class Shooter : MonoBehaviour
{

    [SerializeField]
    GameObject[] weaponsImage;
   

    public Weapons weapon = Weapons.Sniper;
    CinemachineImpulseSource impulse;
    GameObject _inputManager;
    Vector2 aimJoystick;
    public GameObject shootPrefab;
    
   

    [SerializeField]
    sizePlayer life;

    public Transform pointer;

    public float originalYPos;

    bool shooting = false;

    bool hasAbility;

    float shotgunSpread = 0.4f;
    int shotgunCartridges = 15;
    float shotgunDrag = 2;

    float spraySpread = 0.5f;

    public ParticleSystem shootParticle;
    ParticleSystem particles;
    //Sounds
    public AudioSource shoot;
    public AudioSource spray;
    float playSound = 0;
    public float fPitchMax = 1.2f;
    public float fPitchMin = 0.9f;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerControlls controller;
        _inputManager = gameObject.GetComponent<Movement_2>().inputManager;
        controller = _inputManager.GetComponent<InputsController>().globalControls;

        controller.Gameplay.Shoot.started += ctx => ShootAutoTrue();
        //controller.Gameplay.Ultimate.started += ctx => ShootBigDrop();
        controller.Gameplay.Shoot.canceled += ctx => ShootAutoFalse();
        controller.Gameplay.SwitchWeapon.started += ctx => SwitchWeapon();
        impulse = transform.GetComponent<CinemachineImpulseSource>();
        originalYPos = transform.position.y;

        //cameraZoomCambiar.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset *= 0.5f;
        LoadData();
        SaveData();
    }
    void SwitchWeapon()
    {
        //if (weapon == Weapons.Basic)
        //    weapon = Weapons.Auto;
        //else
        //    weapon = Weapons.Auto;
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
                weaponsImage[0].SetActive(false);
                weaponsImage[1].SetActive(false);
                weaponsImage[2].SetActive(false);
                weaponsImage[3].SetActive(false);
                weaponsImage[4].SetActive(true);

                break;
            case Weapons.Auto:
                fireRate = 9;
                weaponsImage[0].SetActive(true);
                weaponsImage[1].SetActive(false);
                weaponsImage[2].SetActive(false);
                weaponsImage[3].SetActive(false);
                weaponsImage[4].SetActive(false);
                break;
            case Weapons.Shotgun:
                fireRate = 1.5f;
                weaponsImage[0].SetActive(false);
                weaponsImage[1].SetActive(true);
                weaponsImage[2].SetActive(false);
                weaponsImage[3].SetActive(false);
                weaponsImage[4].SetActive(false);
                break;
            case Weapons.Triple:
                fireRate = 5;
                weaponsImage[0].SetActive(false);
                weaponsImage[1].SetActive(false);
                weaponsImage[2].SetActive(false);
                weaponsImage[3].SetActive(true);
                weaponsImage[4].SetActive(false);
                break;
            case Weapons.Sniper:
                fireRate = 1;
                weaponsImage[0].SetActive(false);
                weaponsImage[1].SetActive(false);
                weaponsImage[2].SetActive(true);
                weaponsImage[3].SetActive(false);
                weaponsImage[4].SetActive(false);
                break;
            case Weapons.Spray:
                fireRate = 50;
                weaponsImage[0].SetActive(false);
                weaponsImage[1].SetActive(false);
                weaponsImage[2].SetActive(false);
                weaponsImage[3].SetActive(true);
                weaponsImage[4].SetActive(false);
                break;
            default:
                fireRate = 3;
                break;
        }


        if (shooting && Time.time >= nextShoot)
        {
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.FIRERATE, out hasAbility);
            
            if (hasAbility)
            {
                fireRate *= 1.5f;
            }
            
            Debug.Log(fireRate);
            nextShoot = Time.time + 1f / fireRate;
            Shoot();

            //Si las armas no son autom�ticas
            if (weapon == Weapons.Basic || weapon == Weapons.Sniper || weapon == Weapons.Shotgun)
            {
                shooting = false;
            }
        }
        aimJoystick = _inputManager.GetComponent<InputsController>().rightStickDirection;

    }
    public Vector3 aimDirection = new Vector3(1, 1, 1);

    void FixedUpdate()
    {
        if (aimJoystick.magnitude >= 0.1)
        {
            float angle = Mathf.Atan2(aimJoystick.x, aimJoystick.y) * Mathf.Rad2Deg + gameObject.GetComponent<Movement_2>().camera.eulerAngles.y;
            aimDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;

        }
        Vector3 v = gameObject.transform.position + aimDirection * 5;
        v.y = 1.2f;
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
        Vector3 pos = new Vector3(gameObject.transform.position.x, originalYPos, gameObject.transform.position.z);
        switch (weapon)
        {
            case Weapons.Basic:
                shoot.pitch = Random.Range(fPitchMin, fPitchMax);
                shoot.Play();
                Shake();
                aux = Instantiate(shootPrefab, pos + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                particles = Instantiate(shootParticle, gameObject.transform.position + aimDirection * 0.5f, Quaternion.identity);
                particles.transform.LookAt(gameObject.transform.position + aimDirection);

                //Destroy(particles.gameObject, 0.6f);
                break;
            case Weapons.Auto:
                shoot.pitch = Random.Range(fPitchMin, fPitchMax);
                shoot.Play();
                Shake();

                Vector3 AutoAimDirection = aimDirection;
                AutoAimDirection.x = aimDirection.x + Random.Range(-0.05f, 0.05f);
                AutoAimDirection.z = aimDirection.z + Random.Range(-0.05f, 0.05f);

                aux = Instantiate(shootPrefab, pos + AutoAimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 8; /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                shootForce = AutoAimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                SpawnShootParticles(1, 1);

                break;
            case Weapons.Spray:
                
                spray.pitch = Random.Range(0.3f, 0.5f);
                if (playSound <= 0)
                {
                    spray.Play();
                    playSound = 0.2f;
                }
                else 
                {
                    playSound -= Time.deltaTime;
                }
                
                
                Shake();

                Vector3 sprayAimDirection = aimDirection;
                sprayAimDirection.x = aimDirection.x + Random.Range(-spraySpread, spraySpread);
                sprayAimDirection.z = aimDirection.z + Random.Range(-spraySpread, spraySpread);

                aux = Instantiate(shootPrefab, pos + sprayAimDirection * 3f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<SphereCollider>().isTrigger = true;
                aux.GetComponent<BulletScript>().damage = 3;
                float f = Random.Range(1.0f, 2.3f);
                aux.transform.localScale *= f;

                shootForce = sprayAimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce*0.5f);
                aux.GetComponent<BulletScript>().destroyTime = 5;
                int spawnOrNot = Random.Range(0, 2);
                Debug.Log(spawnOrNot);
                if(spawnOrNot != 0)
                {
                    SpawnShootParticles(1.5f, 1);
                }
                break;
            case Weapons.Shotgun:
                shoot.pitch = 0.5f;
                shoot.Play();
                Shake(2);
                for (int i = 0; i < shotgunCartridges; i++)
                {
                    Vector3 shotgunAimDirection = aimDirection;
                    shotgunAimDirection.x = aimDirection.x + Random.Range(-shotgunSpread, shotgunSpread);
                    shotgunAimDirection.z = aimDirection.z + Random.Range(-shotgunSpread, shotgunSpread);

                    aux = Instantiate(shootPrefab, pos + shotgunAimDirection * 1.5f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                    aux.GetComponent<BulletScript>().damage = 15;
                    shootForce = shotgunAimDirection * 100;
                    aux.GetComponent<Rigidbody>().AddForce(shootForce*1.5f);
                    aux.GetComponent<Rigidbody>().drag = shotgunDrag;

                }

                SpawnShootParticles(2f, 2);

                break;
            case Weapons.Triple:
                shoot.pitch = Random.Range(fPitchMin, fPitchMax);
                shoot.Play();
                Shake(1);
                float angle = 15 * Mathf.Deg2Rad;
                //Right
                Vector3 tripleDirection = aimDirection;
                tripleDirection.x = tripleDirection.x * Mathf.Cos(angle) - tripleDirection.y * Mathf.Sin(angle);
                tripleDirection.z = tripleDirection.z * Mathf.Sin(angle) + tripleDirection.y * Mathf.Cos(angle);
                aux = Instantiate(shootPrefab, pos + tripleDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = tripleDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                //Center
                tripleDirection = aimDirection;
                aux = Instantiate(shootPrefab, pos + tripleDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.GetComponent<BulletScript>().damage = 10;
                shootForce = tripleDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce);

                //Left
                //angle = 345 * Mathf.Deg2Rad;
                //tripleDirection = aimDirection;
                //tripleDirection.x = tripleDirection.x * Mathf.Cos(angle) - tripleDirection.y * Mathf.Sin(angle);
                //tripleDirection.z = tripleDirection.z * Mathf.Sin(angle) + tripleDirection.y * Mathf.Cos(angle);
                //aux = Instantiate(shootPrefab, gameObject.transform.position + tripleDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                //aux.GetComponent<BulletScript>().damage = 10;
                //shootForce = tripleDirection * 100;
                //aux.GetComponent<Rigidbody>().AddForce(shootForce);
                break;
            case Weapons.Sniper:
                shoot.pitch = 2f;
                shoot.Play();
                Shake();
                aux = Instantiate(shootPrefab, pos + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
                aux.transform.localScale *= 1.5f;
                aux.GetComponent<BulletScript>().damage = 50;
                shootForce = aimDirection * 100;
                aux.GetComponent<Rigidbody>().AddForce(shootForce * 3);
                SpawnShootParticles(1.5f, 3);
                break;                    
            default:
                break;
        }
    }

    public void SpawnShootParticles(float particlesScale, int particlesNumber)
    {
        for (int i = 0; i < particlesNumber; i++)
        {
            particles = Instantiate(shootParticle, gameObject.transform.position + aimDirection * 0.5f, Quaternion.identity);
            particles.gameObject.transform.localScale *= particlesScale;
            particles.transform.LookAt(gameObject.transform.position + aimDirection);
            Destroy(particles.gameObject, 0.6f);
        }
    }

    //void ShootBigDrop() {

    //    GameObject aux;
    //    Vector3 shootForce;

    //    if (life.life > 1)
    //    {
    //        ShakeUltimate();
    //        life.life -= 1;
    //        life.changed = false;
    //        aux = Instantiate(bigDropPrefab, gameObject.transform.position + aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
    //        aux.GetComponent<BulletScript>().damage = 100;
    //        shootForce = aimDirection * 100;
    //        aux.GetComponent<Rigidbody>().AddForce(shootForce);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WeaponPedestal"))
        {

            weapon = (Weapons)other.GetComponent<WeaponPedestalScript>().newWeaponNumber;
        }
    }

    void SaveData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            SingletonDataSaver.instance.weaponsSaved = weapon;

        }
    }
    void LoadData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            Debug.Log(SingletonDataSaver.instance.weaponsSaved);
            weapon = SingletonDataSaver.instance.weaponsSaved;
        }
    }
    private void OnDestroy()
    {
        if(gameObject.GetComponent<sizePlayer>().life <= 0)
        {

        }
        else
            SaveData();
    }
}
