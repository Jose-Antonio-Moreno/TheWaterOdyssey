using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBubble_Script : MonoBehaviour
{
    public AudioSource healSound;
    GameObject life;

    void Start()
    {
        life = GameObject.FindGameObjectWithTag("Player");
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (life.GetComponent<sizePlayer>().life < 5) 
            {
                healSound.Play();
                gameObject.transform.position = new Vector3(300, 300, 300);
                Invoke("Des", 2f);
            }
        }
    }

    private void Des()
    {
        Destroy(this.gameObject);
    }
}
