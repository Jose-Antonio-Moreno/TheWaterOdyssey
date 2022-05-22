using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDropController : MonoBehaviour
{
    [SerializeField] public Transform[] firepoints;
    [SerializeField] public GameObject bubblePrefab;
    public bool hasExploded = false;
    private void Update()
    {
        if (hasExploded) 
        {
            Explosion();
        }
    }
    private void Explosion()
    {
        for (int i = 0; i < firepoints.Length; i++)
        {
            Vector3 direction1 = (firepoints[i].position - this.transform.position).normalized;
            GameObject aux = Instantiate(bubblePrefab, gameObject.transform.position + direction1 * 1f, Quaternion.identity);
            Vector3 shootForce = direction1 * 80;
            aux.GetComponent<Rigidbody>().AddForce(shootForce);
        }

    }
}
