using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPLayer : MonoBehaviour
{
    private void Awake()
    {
        PlayerData data = saveAndloadsystem.LoadPlayerData();

        //Setting the game money to the loaded money 
        playerCoinManagment.playerMoney = 90000000;

        //setting the loaded stages to the game
        MainMenuManager.stageOfFireRate = data.stageOfFireRate;
        MainMenuManager.stageOfHealth = data.stageOfHealth;
        MainMenuManager.stageOfRocketCapacity = data.stageOfcapacity;
        MainMenuManager.stageOfRocketFireRate = data.stageOfrocketFireRate;
        MainMenuManager.stageOfRocketFireRate = data.stageOfrocketFireRate;
    }
}
