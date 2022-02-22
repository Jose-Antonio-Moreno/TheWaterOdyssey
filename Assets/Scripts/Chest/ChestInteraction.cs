using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestInteraction : MonoBehaviour
{
    [SerializeField]
    Animator chestAnimation;
    [SerializeField]
    GameObject weapon;

    float timeToBeDestroyed;
    bool readyToBeDestroyed;
    void Start()
    {
        timeToBeDestroyed = 6;
        readyToBeDestroyed = false;
    }
    void Update()
    {
        weapon.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        if (readyToBeDestroyed) 
        {
            if (timeToBeDestroyed <= 0)
            {
                Destroy(this.gameObject);
            }
            else { timeToBeDestroyed -= Time.deltaTime; }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //Instanciar el objecte
            GameObject x = Instantiate(weapon);
            x.transform.localScale = this.transform.localScale / 20;
            chestAnimation.SetBool("IsOpen", true);
            readyToBeDestroyed = true;
        }
    }
}
