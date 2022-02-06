using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Michsky.LSS;
public class firiingModeControl : MonoBehaviour
{
    public LoadingScreenManager LoadingScreenManager;

    public Text loadingText;

    public static bool isPaused;
    public static bool isUsingSprayMode = true;
    private AudioSource aud;

    //pause menu
    public GameObject pauseMenuHolder;
    public Material bossMaterial;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void sprayMode()
    {
        isUsingSprayMode = true;
        aud.Play();
    }

    public void rocketMode()
    {
        isUsingSprayMode = false;
        aud.Play();
    }

    //PAUSE button
    public void pauseButton()
    {
        isPaused = true;
        Time.timeScale = 1.0f;
        backgroundMusicScript.aud.volume = 0.15f;
        Time.timeScale = 0;
        pauseMenuHolder.SetActive(true);
    }

    public void continueButotn()
    {
        isPaused = false;
        backgroundMusicScript.aud.volume = 0.4f;
        Time.timeScale = 1;
        pauseMenuHolder.SetActive(false);
    }

    IEnumerator mainMenuSceneLoad()
    {
        LevelLoader.anim.SetBool("start", false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        
        while (!asyncLoad.isDone)
        {
            loadingText.text = "LOADING " + asyncLoad.progress * 100 + "%";
            yield return null;
        }
    }

    public void returnToMainMenu()
    {
        isPaused = false;

        playerCoinManagment.playerMoney += playerCoinManagment.inGamePlayerMoney;
        saveAndloadsystem.SavePlayerData();
        playerCoinManagment.inGamePlayerMoney = 0;

        bossMaterial.SetFloat("dissolveAmount", 1);

        LoadingScreenManager.LoadScene("MainMenu");
    }
    
}
