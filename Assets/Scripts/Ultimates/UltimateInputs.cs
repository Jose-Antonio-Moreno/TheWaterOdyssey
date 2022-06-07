using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UI;

public class UltimateInputs : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    GameObject _inputManager;
    public Shooter variables;
    
    [SerializeField]
    GameObject bigDropPrefab;
    [SerializeField]
    sizePlayer life;

    bool hasUltimate;
    bool hasAbility;

    float coolDownTime = 2f;
    bool canUse = true;
    bool isUsing = false;

    float spraySpread = 0.5f;


    //Sounds
    public AudioSource dropinomicon;
    public AudioSource bigDrop;

    float playSound = 0;
    public AudioSource spray;




    void Start() 
    {
        PlayerControlls controller;
        _inputManager = gameObject.GetComponent<Movement_2>().inputManager;
        controller = _inputManager.GetComponent<InputsController>().globalControls;
        controller.Gameplay.Ultimate.started += ctx => UltimateToUse();

        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        if (isUsing) 
        {
            if (coolDownTime <= 0)
            {
                isUsing = false;
                canUse = true;
                coolDownTime = 2f;
            }
            else 
            {
                coolDownTime -= Time.deltaTime;
                canUse = false;
            }
        }
        if (shootingSpray)
        {
            BubbleSpray();
        }
    }

    public void ShakeUltimate()
    {
        impulse.GenerateImpulse(2);
    }
    bool shootingSpray = false;
    void UltimateToUse() 
    {
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(EUltimates.BIGDROP, out hasUltimate);
        if (hasUltimate) 
        {
            if (canUse) 
            {
                ShootBigDrop();
                Instantiate(life.hitParticles, transform.position, transform.rotation);
                return;
            }
        }
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(EUltimates.DROPINOMICON, out hasUltimate);
        if (hasUltimate)
        {
            if (canUse) 
            {
                Dropinomicon();
                Instantiate(life.hitParticles, transform.position, transform.rotation);
                return;
            }
        }
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(EUltimates.BUBBLESPRAY, out hasUltimate);
        if (hasUltimate)
        {
            if (canUse)
            {
                if (life.life > 1)
                {
                    life.life -= 1;
                    life.changed = false;
                    shootingSpray = true;
                    Invoke("StopSpray", 2);
                    Instantiate(life.hitParticles, transform.position, transform.rotation);
                    return;
                }
            }
        }

    }
    void StopSpray()
    {
        shootingSpray = false;
    }
    void ShootBigDrop()
    {
        GameObject aux;
        Vector3 shootForce;
        Vector3 pos;
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.BIGBUBBLE, out hasAbility);
        if (hasAbility)
        {
            pos = new Vector3(gameObject.transform.position.x, variables.originalYPos + 1.5f, gameObject.transform.position.z);
        }
        else 
        {
            pos = new Vector3(gameObject.transform.position.x, variables.originalYPos + 1, gameObject.transform.position.z);
        }
        if (life.life > 1)
        {
            bigDrop.Play();
            ShakeUltimate();
            life.life -= 1;
            life.changed = false;
            aux = Instantiate(bigDropPrefab, pos + variables.aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
            aux.GetComponent<BigDropController>().damage = 100;
            shootForce = variables.aimDirection * 100;
            aux.GetComponent<Rigidbody>().AddForce(shootForce);
            isUsing = true;
        }
    }
    void Dropinomicon() 
    {
        if (life.life > 1) 
        {
            dropinomicon.Play();
            ShakeUltimate();
            life.life -= 1;
            life.changed = false;
            GameObject[] gb = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] dummy = GameObject.FindGameObjectsWithTag("Dummy");
            for (int i = 0; i < gb.Length; i++)
            {
                // Collider[] enemies = Physics.OverlapSphere(gameObject.transform.position, 100, Layer);
                //enemies[i].gameObject.GetComponent<UltimateBehaviour>();
                UltimateInterface ultimate = gb[i].GetComponent<UltimateBehaviour>();
                if (ultimate != null)
                    ultimate.ActivateDropinomicon();
            }
            for (int i = 0; i < dummy.Length; i++) 
            {
                UltimateInterface ultimate = dummy[i].GetComponent<UltimateBehaviour>();
                if (ultimate != null)
                    ultimate.ActivateDropinomicon();
            }
            isUsing = true;
        }
    }

    void BubbleSpray() 
    {


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
            Vector3 aimDirection = variables.aimDirection;
            aimDirection.y = 0;
            Vector3 shootForce;

            Vector3 sprayAimDirection = aimDirection;
            sprayAimDirection.x = aimDirection.x + Random.Range(-spraySpread, spraySpread);
            sprayAimDirection.z = aimDirection.z + Random.Range(-spraySpread, spraySpread);
            GameObject aux;
            Vector3 pos = new Vector3(gameObject.transform.position.x, variables.originalYPos, gameObject.transform.position.z);

            aux = Instantiate(variables.shootPrefab, pos + sprayAimDirection * 3f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
            aux.GetComponent<SphereCollider>().isTrigger = true;
            aux.GetComponent<BulletScript>().damage = 10; ///DAMAGE
            float f = Random.Range(1.0f, 2.3f);
            aux.transform.localScale *= f;

            shootForce = sprayAimDirection * 100;
            aux.GetComponent<Rigidbody>().AddForce(shootForce * 0.5f);
            aux.GetComponent<BulletScript>().destroyTime = 5;
            int spawnOrNot = Random.Range(0, 2);
            Debug.Log(spawnOrNot);
            if (spawnOrNot != 0)
            {
                variables.SpawnShootParticles(1.5f, 1);
            }
       
    }
    public void Shake()
    {
        impulse.GenerateImpulse(0.25f);
    }
}
