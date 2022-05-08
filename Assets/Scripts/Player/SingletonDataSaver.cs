using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
            Debug.Log("sdsds");

            weaponsSaved = Weapons.Basic;
            //for (int i = 0; i < (int)EUltimates.DUMMY; i++)
            //{
            //    savedUltimates.Add((EUltimates)i, false);
            //}
            savedUltimates[EUltimates.BIGDROP] = false;
            savedUltimates[EUltimates.DROPINOMICON] = false;

            //for (int i = 0; i < (int)EAbilities.DUMMY; i++)
            //{
            //    savedSkills.Add((EAbilities)i, false);
            //}
            savedSkills[EAbilities.POISON] = false;
            savedSkills[EAbilities.BOUNCY] = false;
            savedSkills[EAbilities.LIGHTSTEP] = false;
            savedSkills[EAbilities.FIRERATE] = false;
            savedSkills[EAbilities.SHIELDBUBBLE] = false;
            savedSkills[EAbilities.BIGBUBBLE] = false;
        }
    }
    public void RestartData()
    {
        for (int i = 0; i < (int)EUltimates.DUMMY; i++)
        {
            savedUltimates[(EUltimates)i] = false;
        }

        weaponsSaved = Weapons.Basic;
 
        savedSkills[EAbilities.POISON] = false;
        savedSkills[EAbilities.BOUNCY] = false;
        savedSkills[EAbilities.LIGHTSTEP] = false;
        savedSkills[EAbilities.FIRERATE] = false;
        savedSkills[EAbilities.SHIELDBUBBLE] = false;
        savedSkills[EAbilities.BIGBUBBLE] = false;
    }
}
