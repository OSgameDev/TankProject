using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int PlayerMoney;
    public int stageOfFireRate;
    public int stageOfHealth;
    public int stageOfcapacity;
    public int stageOfrocketFireRate;
    public int stageOfSpeed;

    public bool isBoughtSecondBulletSpray = false;
    public PlayerData()
    {
        //money
        PlayerMoney = playerCoinManagment.playerMoney; 

        //tank vars
        stageOfFireRate = MainMenuManager.stageOfFireRate;
        stageOfHealth = MainMenuManager.stageOfHealth;
        stageOfcapacity = MainMenuManager.stageOfRocketCapacity;
        stageOfSpeed = MainMenuManager.stageOfSpeed;
        stageOfrocketFireRate = MainMenuManager.stageOfRocketFireRate;
    }
}