using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MainMenuScript : MonoBehaviour
{

   
    public AudioMixer audioMixer;


    public Dropdown resolutionDropdown;

    
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) currentResolution = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();

        

    }
    public void Play()
    {
        SceneManager.LoadScene("LEVEL_1");
    }

    public void Exit()
    {

        Application.Quit();

    }

    public void TutorialScene()
    {

        SceneManager.LoadScene("SceneTutorial");

    }
    public void setQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

    }

    public void SetFullScreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;

    }
    public void SetResolution(int resolutionIndex)
    {

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("MasterVolume", volume);

    }

}
