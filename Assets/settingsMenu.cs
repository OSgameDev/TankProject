
///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOS™     ////////////////////////
////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer musicAudioMixer;

    public Dropdown quality;
    public Dropdown frameRate;

    public static int selectedQualityIndex;
    public static int selectedFPS;

    private bool isSaved = false;
    private bool backedWithoutSaving = false;
    private int currentQ;
    private int currentF;

    private void Awake()
    {
        currentQ = quality.value;
        currentF = frameRate.value;
        try
        {
            quality.value = PlayerPrefs.GetInt("qualityIndex");
            frameRate.value = PlayerPrefs.GetInt("fpsIndex");
        }
        catch (System.Exception)
        {
            quality.value = selectedQualityIndex;
            frameRate.value = selectedFPS;
        }
    }

    //QUALITY and FPS part

    //Getting the choices
    public void setQuality(int index)
    {
        selectedQualityIndex = index;
    }
    public void setFrameRate(int index)
    {
        selectedFPS = index;
    }

    //Setting the things and that 
    public void setQualityAndFps()
    {
        //Setting Quality
        switch (selectedQualityIndex)
        {
            case 0:
                QualitySettings.SetQualityLevel(3);
                break;
            case 1:
                QualitySettings.SetQualityLevel(2);
                break;
            case 2:
                QualitySettings.SetQualityLevel(1);
                break;
            case 3:
                QualitySettings.SetQualityLevel(0);
                break;

            default:
                QualitySettings.SetQualityLevel(3);
                break;
        }

        switch (selectedFPS)
        {
            case 0:
                Application.targetFrameRate = 400;
                break;
            case 1:
                Application.targetFrameRate = 120;
                break;
            case 2:
                Application.targetFrameRate = 90;
                break;
            case 3:
                Application.targetFrameRate = 60;
                break;
            case 4:
                Application.targetFrameRate = 30;
                break;
            default:
                Application.targetFrameRate = 400;
                break;
        }
        isSaved = true;
        saveQualitySettings();
    }
    public void backButtonCheck()
    {
        if (!isSaved)
        {
            quality.value = currentQ;
            frameRate.value = currentF;
        }
        isSaved = false;
    }
    private void saveQualitySettings()
    {
        PlayerPrefs.SetInt("qualityIndex", selectedQualityIndex);
        PlayerPrefs.SetInt("fpsIndex", selectedFPS);
        PlayerPrefs.Save();
    }

    //Volume Part of settings menu
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void setMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("mVolume", volume);
    }
}
