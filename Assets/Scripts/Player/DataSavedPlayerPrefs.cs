using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSavedPlayerPrefs : MonoBehaviour
{
    string weaponPrefsName = "weapon";

    void Awake()
    {
        LoadData();
    }

    void SaveData()
    {
        Weapons weapon = gameObject.GetComponent<Shooter>().weapon;
        Debug.Log(weapon);
        PlayerPrefs.SetInt(weaponPrefsName, (int)weapon);
    }
    void LoadData()
    {
        Weapons weapon = (Weapons)PlayerPrefs.GetInt(weaponPrefsName,0);
        Debug.Log(weapon);

    }
    private void OnDestroy()
    {
        SaveData();
    }

}
