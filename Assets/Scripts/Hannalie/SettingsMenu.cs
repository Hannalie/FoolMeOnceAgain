using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;

    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropDown;

    public void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
        List<string> list = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            list.Add(option);
        }
        resolutionDropDown.AddOptions(list);
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
