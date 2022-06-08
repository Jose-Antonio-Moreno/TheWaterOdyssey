using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SkillsMenuManger : MonoBehaviour
{
    public GameObject _inputManager;

    GameObject player;
    private GameObject pause;

    public GameObject hud;
    public GameObject weapons;
    public GameObject ultimates;
    public GameObject abilities;

    public AudioMixer audioMixer;

  

    public Dropdown resolutionDropdown;

    private bool activate = false;
    Resolution[] resolutions;
    private void Start()
    {
       resolutions =  Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolution=0;

        for (int i = 0; i  < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) currentResolution = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();

        PlayerControlls controller;
        controller = _inputManager.GetComponent<InputsController>().globalControls;
        controller.Gameplay.Pause.started += ctx => setSkillMenuPanel();

        pause = gameObject.transform.GetChild(0).gameObject;


    }

    void setSkillMenuPanel()
    {
        if (pause.active == true)
        {
            hud.SetActive(true);
            weapons.SetActive(true);
            ultimates.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 1f;

        }
        else if (pause.active == false)
        {
            hud.SetActive(false);
            weapons.SetActive(false);
            ultimates.SetActive(false);
            pause.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void setQuality(int qualityIndex) {

        QualitySettings.SetQualityLevel(qualityIndex);
    
    }

    public void SetFullScreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;

    }

    public void SetResolution(int resolutionIndex) {

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    
    }
    public void SetVolume(float volume) {

        audioMixer.SetFloat("MasterVolume", volume);
    
    }

    public void goMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void goContinue()
    {
        Time.timeScale = 1f;
       
    }
    public void SelectPoison()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.POISON] = true;
        
    }
    public void SelectDoubleEdge()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.DOUBLEEDGE] = true;
    }
    public void SelectIce()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.ICE] = true;
    }
    public void SelectLightstep()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.LIGHTSTEP] = true;
    }
    public void SelectBouncy()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.BOUNCY] = true;
    }
    public void SelectFireRate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.FIRERATE] = true;
    }
    public void SelectShieldBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.SHIELDBUBBLE] = true;

    }
    public void SelectBigBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[EAbilities.BIGBUBBLE] = true;
    }

}
