using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestInteraction : MonoBehaviour
{
    [SerializeField]
    Animator chestAnimation;
    [SerializeField]
    GameObject []weapon;

    int random;
    bool spawnItem;
    float timeToBeDestroyed;
    bool readyToBeDestroyed;
    void Start()
    {
        spawnItem = false;
        timeToBeDestroyed = 6;
        readyToBeDestroyed = false;
        
        random = Random.Range(0, weapon.Length);

    }
    void Update()
    {
        if (!spawnItem)
        {
            spawnItem = true;
            weapon[random].transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }    
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
            GameObject x = Instantiate(weapon[random]);
            x.transform.localScale = this.transform.localScale *10;
            chestAnimation.SetBool("IsOpen", true);
            readyToBeDestroyed = true;
        }
    }
}
