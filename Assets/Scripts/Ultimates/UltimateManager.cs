using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateManager : MonoBehaviour
{
    public enum EUltimates {BIGDROP, DROPINOMICON, DUMMY };
    public Dictionary<EUltimates, bool> DUltimates;

    [SerializeField]
    GameObject[] ultimatesImage;

    void Awake()
    {
        DUltimates = new Dictionary<EUltimates, bool>();
        EUltimates ultimate;
        for (int i = 0; i < (int)EUltimates.DUMMY; i++) 
        {
            ultimate = (EUltimates)i;
            DUltimates.Add(ultimate, false);
        }
        DUltimates[EUltimates.BIGDROP] = false;
        DUltimates[EUltimates.DROPINOMICON] = false;
    }

 
}


