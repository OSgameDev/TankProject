using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainGameUIManager : MonoBehaviour
{
    //variables 

    public AdsManager ads;
    public static bool isSucsses = false;


    //enumerators
    IEnumerator mainMenuSceneLoad()
    {
        LevelLoader.anim.SetBool("start", false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    //methods

    public void continueByWatchingAD()
    {
        ads.playRewardedRestartAD(onSucssesContinue);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void returnToMainMenu()
    {
        //Adding in game money to player money and re setting
        playerCoinManagment.playerMoney += playerCoinManagment.inGamePlayerMoney;
        playerCoinManagment.inGamePlayerMoney = 0;

        //re setting variables that were used 
        GameManger.isSpawnTwoCoins = false;

        //saving player's money
        saveAndloadsystem.SavePlayerData();

        //Loading Main Menu Scene
        LevelLoader.anim.SetBool("start", true);
        StartCoroutine(mainMenuSceneLoad());
    }

    //After watching ad succsessfully
    void onSucssesContinue()
    {
        isSucsses = true;
        TankPlayerMovement.isTankAlive = true;
        TankPlayerMovement.CurrentHealth = TankPlayerMovement.tankHealth;
    }
}
