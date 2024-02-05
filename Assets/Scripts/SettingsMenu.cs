using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.Mathematics;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private Resolution[] resolutions;

    [SerializeField] private Toggle toggle;

    [SerializeField]
    private TMP_Dropdown dropdownResolution;

    public Slider musicSlider;
    public Slider soundEffectSlider;

    private void Awake()
    {
        toggle.isOn = Screen.fullScreen;
    }

    private void Start()
    {
        audioMixer.GetFloat("Music", out float valueMusique);
        musicSlider.value = math.pow(10,valueMusique/20);
        
        audioMixer.GetFloat("Sound", out float valueSoundEffect);
        soundEffectSlider.value = math.pow(10,valueSoundEffect/20);
        
        resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].ToString();
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height )
            {
                currentResolutionIndex = i;
            }
        }
        dropdownResolution.ClearOptions();
        dropdownResolution.AddOptions(options);
        
        dropdownResolution.value = currentResolutionIndex;
        dropdownResolution.RefreshShownValue();

    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetSoundEffect(float volume)
    {
        audioMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Application.targetFrameRate = resolution.refreshRate;

    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
