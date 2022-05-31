using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour
{
    public GameObject Fences;
    public GameObject Boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fences.SetActive(true);
            Boss.SetActive(true);
        }

    }
}
