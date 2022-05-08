using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDataSaver : MonoBehaviour
{
    //Datos a guardar : habilidades, armas
    public static SingletonDataSaver instance;

    public Weapons weaponsSaved;
    public Dictionary<EAbilities, bool> savedSkills;
    public Dictionary<EUltimates, bool> savedUltimates;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

}
