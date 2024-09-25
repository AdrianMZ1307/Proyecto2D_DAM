using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class configurationMenu : MonoBehaviour
{
    public static configurationMenu instance;

    public Dropdown cmbResolutions;
    public Slider slVolume;
    public Toggle fullScreen;
    public float volume = 0f;
    Resolution[] resolutions;
    void Start()
    {
#if !(UNITY_STANDALONE || UNITY_WEBGL)
        Destroy(GameObject.FindGameObjectWithTag("ConfigButton"));
        return;
#endif

        int currentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        cmbResolutions.ClearOptions();

        List<String> opciones = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + "x" + resolutions[i].height;
            opciones.Add(opcion);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        cmbResolutions.AddOptions(opciones);
        cmbResolutions.value = currentResolutionIndex;
        cmbResolutions.RefreshShownValue();

    }

    public void SetResolution(int value)
    {
        Resolution r = resolutions[value];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void SetVolume(float value)
    {
        GameObject.FindGameObjectWithTag("Title").GetComponent<AudioSource>().volume = value;
        volume = GameObject.FindGameObjectWithTag("Title").GetComponent<AudioSource>().volume;
        Debug.Log(volume);
        instance = this;
    }


    public void setFullScreen(bool value)
    {
        Screen.fullScreen = value;
    }
}
