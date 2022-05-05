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

    void Start() 
    {
        PlayerControlls controller;
        _inputManager = gameObject.GetComponent<Movement_2>().inputManager;
        controller = _inputManager.GetComponent<InputsController>().globalControls;
        controller.Gameplay.Ultimate.started += ctx => UltimateToUse();

        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeUltimate()
    {

        impulse.GenerateImpulse(0.55f);
    }

    void UltimateToUse() 
    {
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(UltimateManager.EUltimates.BIGDROP, out hasUltimate);
        if (hasUltimate) 
        {
            ShootBigDrop();
        }
        GameObject.Find("Armature").GetComponent<UltimateManager>().DUltimates.TryGetValue(UltimateManager.EUltimates.DROPINOMICON, out hasUltimate);
        if (hasUltimate)
        {
            Dropinomicon();
        }
    }
    void ShootBigDrop()
    {
        GameObject aux;
        Vector3 shootForce;

        if (life.life > 1)
        {
            ShakeUltimate();
            life.life -= 1;
            life.changed = false;
            aux = Instantiate(bigDropPrefab, gameObject.transform.position + variables.aimDirection * 2f * (gameObject.transform.localScale.x / 100), Quaternion.identity);
            aux.GetComponent<BulletScript>().damage = 100;
            shootForce = variables.aimDirection * 100;
            aux.GetComponent<Rigidbody>().AddForce(shootForce);
        }
    }
    void Dropinomicon() 
    {
        ShakeUltimate();
        life.life -= 1;
        life.changed = false;


        GameObject[] gb = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gb.Length; i++)
        {
            //
            // Collider[] enemies = Physics.OverlapSphere(gameObject.transform.position, 100, Layer);
            //enemies[i].gameObject.GetComponent<UltimateBehaviour>();
            UltimateInterface ultimate = gb[i].GetComponent<UltimateBehaviour>();
            if(ultimate != null)
                ultimate.ActivateDropinomicon();

        }
    }
}
