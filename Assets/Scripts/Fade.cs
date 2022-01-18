using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private Animator anim, anim2;

       private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Player") {

            anim.SetBool("FadeIn", true);
            anim2.SetBool("Fade", true);
        }
    }

}
