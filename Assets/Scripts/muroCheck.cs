using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muroCheck : MonoBehaviour
{
    public Rigidbody pj;
    public GameObject muro;

    // Update is called once per frame
    void Update()
    {
        if (pj.mass > 20) muro.SetActive(false);
    }
}
