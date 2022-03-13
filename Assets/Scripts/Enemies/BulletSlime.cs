using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlime : MonoBehaviour
{
    float destroyTime;

    void Start()
    {
        destroyTime = 2;
    }

    private void Update()
    {
        Invoke("des", destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            Invoke("des", 0.5f);
        }
    }

    private void des()
    {
        Destroy(this.gameObject);
    }
}
