using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class firiingModeControl : MonoBehaviour
{
    public Text loadingText;

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
        backgroundMusicScript.aud.volume = 0.15f;
        Time.timeScale = 0;
        pauseMenuHolder.SetActive(true);
    }

    public void continueButotn()
    {
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
        //saving player money and re setting in game money;
        playerCoinManagment.playerMoney += playerCoinManagment.inGamePlayerMoney;
        saveAndloadsystem.SavePlayerData();
        playerCoinManagment.inGamePlayerMoney = 0;

        //Re setting the boss material shader
        bossMaterial.SetFloat("dissolveAmount", 1);

        //Loading Main Menu Scene
        LevelLoader.anim.SetBool("start", true);
        StartCoroutine(mainMenuSceneLoad());
    }
    
}
