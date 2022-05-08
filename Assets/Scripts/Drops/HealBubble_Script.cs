using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBubble_Script : MonoBehaviour
{
    public AudioSource healSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healSound.Play();
            gameObject.transform.position = new Vector3(300,300,300);
            Invoke("Des", 2f);
        }
    }

    private void Des()
    {
        Destroy(this.gameObject);
    }
}
