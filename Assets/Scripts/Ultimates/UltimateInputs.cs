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

    //Sounds
    public AudioSource dropinomicon;
    public AudioSource bigDrop;



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
    }

    public void ShakeUltimate()
    {
        impulse.GenerateImpulse(2);
    }

    void UltimateToUse() 
    {
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(EUltimates.BIGDROP, out hasUltimate);
        if (hasUltimate) 
        {
            if (canUse) 
            {
                ShootBigDrop();
            }
        }
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(EUltimates.DROPINOMICON, out hasUltimate);
        if (hasUltimate)
        {
            if (canUse) 
            {
                Dropinomicon();
            }
        }
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

    }
}
