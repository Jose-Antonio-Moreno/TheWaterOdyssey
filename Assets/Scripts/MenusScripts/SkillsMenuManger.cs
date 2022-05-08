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
    private GameObject botones;

    public Image hud;

    public AudioMixer audioMixer;


    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
       resolutions =  Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolution=0;
        for (int i = 0; i < resolutions.Length; i++) {

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

        botones = gameObject.transform.GetChild(0).gameObject;


    }


        
    void setSkillMenuPanel()
    {
        if (botones.active == true)
        {
            hud.enabled = true;
            botones.SetActive(false);
            Time.timeScale = 1f;

        }
        else if (botones.active == false)
        {
            hud.enabled = false;
            botones.SetActive(true);
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

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.POISON] = true;
        
    }
    public void SelectDoubleEdge()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.DOUBLEEDGE] = true;
    }
    public void SelectIce()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.ICE] = true;
    }
    public void SelectLightstep()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.LIGHTSTEP] = true;
    }
    public void SelectBouncy()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BOUNCY] = true;
    }
    public void SelectFireRate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.FIRERATE] = true;
    }
    public void SelectShieldBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.SHIELDBUBBLE] = true;

    }
    public void SelectBigBubble()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<SkillManager>().DSkills[SkillManager.EAbilities.BIGBUBBLE] = true;
    }

}
