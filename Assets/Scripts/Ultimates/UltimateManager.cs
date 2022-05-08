using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EUltimates {BIGDROP, DROPINOMICON, DUMMY };

public class UltimateManager : MonoBehaviour
{
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
        LoadData();
    }

    private void Update()
    {
        if (DUltimates[EUltimates.BIGDROP]) {

            ultimatesImage[0].SetActive(true);
            ultimatesImage[1].SetActive(false);
        
        }
        if (DUltimates[EUltimates.DROPINOMICON])
        {

            ultimatesImage[0].SetActive(false);
            ultimatesImage[1].SetActive(true);

        }
    }
    void SaveData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            SingletonDataSaver.instance.savedUltimates = DUltimates;
        }
    }
    void LoadData()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2 && SingletonDataSaver.instance.savedUltimates != null)
        {
            DUltimates = SingletonDataSaver.instance.savedUltimates;
        }
    }
    private void OnDestroy()
    {
        SaveData();
    }
}


