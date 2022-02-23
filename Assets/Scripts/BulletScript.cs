using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletScript : MonoBehaviour
{
    CinemachineImpulseSource impulse;

    private void Start()
    {
        impulse = transform.GetComponent<CinemachineImpulseSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Invoke("des", 1);
        gameObject.SetActive(false);
        if (other.CompareTag("Enemy"))
        {
            impulse.GenerateImpulse(1f);
        }


    }

    private void des()
    {
        Destroy(this.gameObject);

    }
}
