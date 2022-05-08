using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EAbilities {POISON, DOUBLEEDGE, ICE, LIGHTSTEP, DISCOUNT, DAMAGET, SLOWT, FIRERATE, BOUNCY, SHIELDBUBBLE, BIGBUBBLE, DUMMY};

public class SkillManager : MonoBehaviour
{
    public Dictionary<EAbilities, bool> DSkills;
    
    
    void Awake()
    {
        DSkills = new Dictionary<EAbilities, bool>();

        EAbilities ability;

        for (int i = 0; i < (int)EAbilities.DUMMY; i++)
        {
            ability = (EAbilities)i;
            DSkills.Add(ability, false);
        }
        DSkills[EAbilities.POISON] = false;
        DSkills[EAbilities.BOUNCY] = false;
        DSkills[EAbilities.LIGHTSTEP] = false;
        DSkills[EAbilities.FIRERATE] = false;
        DSkills[EAbilities.SHIELDBUBBLE] = false;
        DSkills[EAbilities.BIGBUBBLE] = false;
        LoadData();
    }
    private void Update()
    {
        //Debug.Log(DSkills[EAbilities.LIGHTSTEP]);

    }
    void SaveData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            SingletonDataSaver.instance.savedSkills = DSkills;
        }
    }
    void LoadData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2 && SingletonDataSaver.instance.savedSkills != null)
        {
            DSkills = SingletonDataSaver.instance.savedSkills;
        }
    }
    private void OnDestroy()
    {
        SaveData();
    }

}
