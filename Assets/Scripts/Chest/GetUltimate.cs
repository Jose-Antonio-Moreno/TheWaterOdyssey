using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUltimate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            if (this.CompareTag("BigDrop")) other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = true;
            else { other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.BIGDROP] = false; }
            if (this.CompareTag("Dropinomicon")) other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = true;
            else { other.GetComponent<UltimateManager>().DUltimates[UltimateManager.EUltimates.DROPINOMICON] = false; }
        }*/
    }
}
