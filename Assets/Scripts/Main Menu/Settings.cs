using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Resolution[] resolutions;
    public TextMeshProUGUI resolutionText;


    public AudioMixer AudioMixer;
    public Slider MasterSlider;
    public TextMeshProUGUI MasterText;
    public Slider MusicSlider;
    public TextMeshProUGUI MusicText;
    public Slider SFXSlider;
    public TextMeshProUGUI SFXText;


    private int resInt = 0;
    private void Start()
    {
        resolutionText.text = PlayerPrefs.GetInt("Width").ToString() + "x" + PlayerPrefs.GetInt("Height").ToString();
        resInt = PlayerPrefs.GetInt("ResolutionInt");
        MasterSlider.value = PlayerPrefs.GetInt("MasterValumeDontRemember");
        MusicSlider.value = PlayerPrefs.GetInt("MusicValumeDontRemember");
        SFXSlider.value = PlayerPrefs.GetInt("SFXValumeDontRemember");
    }

    private void FixedUpdate()
    {
        MasterText.text = ((int)MasterSlider.value+80).ToString();
        AudioMixer.SetFloat("MasterVolume", (int)MasterSlider.value);
        MusicText.text = ((int)MusicSlider.value + 80).ToString();
        AudioMixer.SetFloat("MusicVolume", (int)MusicSlider.value);
        SFXText.text = ((int)SFXSlider.value + 80).ToString();
        AudioMixer.SetFloat("SFXVolume", (int)SFXSlider.value);
        PlayerPrefs.SetInt("MasterValumeDontRemember", (int)MasterSlider.value);
        PlayerPrefs.SetInt("MusicValumeDontRemember", (int)MusicSlider.value);
        PlayerPrefs.SetInt("SFXValumeDontRemember", (int)SFXSlider.value);
    }

    public void ClickOnLeftRes() 
    {
        resInt--;
        if (resInt < 0)
            resInt = resolutions.Length - 1;
        resolutionText.text = resolutions[resInt].width.ToString() + "x" + resolutions[resInt].height.ToString();
        PlayerPrefs.SetInt("Width", resolutions[resInt].width);
        PlayerPrefs.SetInt("Height", resolutions[resInt].height);
        PlayerPrefs.SetInt("ResolutionInt", resInt);
    }
    public void ClickOnRightRes()
    {
        resInt++;
        if (resInt > resolutions.Length - 1)
            resInt = 0;
        resolutionText.text = resolutions[resInt].width.ToString() + "x" + resolutions[resInt].height.ToString();
        resolutionText.text = resolutions[resInt].width.ToString() + "x" + resolutions[resInt].height.ToString();
        PlayerPrefs.SetInt("Width", resolutions[resInt].width);
        PlayerPrefs.SetInt("Height", resolutions[resInt].height);
        PlayerPrefs.SetInt("ResolutionInt", resInt);
    }
    public void ClickOnApplySettings()
    {
        Screen.SetResolution(resolutions[resInt].width, resolutions[resInt].height, true);
    }
}


[System.Serializable]
public class Resolution
{
    public int width;
    public int height;
}