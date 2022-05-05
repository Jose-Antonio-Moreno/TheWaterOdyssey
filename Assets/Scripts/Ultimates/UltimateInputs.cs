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
    }
    
    public void ShakeUltimate(float intensity)
    {
        impulse.GenerateImpulse(intensity);
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
            ShakeUltimate(0.55f);
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
        Debug.Log("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM");
        ShakeUltimate(0.55f);
        life.life -= 1;
        life.changed = false;
        UltimateInterface ultimate = gameObject.GetComponent<UltimateBehaviour>();
        ultimate.ActivateDropinomicon();
    }
}
