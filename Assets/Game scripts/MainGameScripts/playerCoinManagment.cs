using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerCoinManagment : MonoBehaviour
{
    public static int playerMoney = 0;
    public static int inGamePlayerMoney = 0;
    public Text displayMoney;

    // Update is called once per frame
    void Update()
    {
        //updating money display
        displayMoney.text = " "+ inGamePlayerMoney.ToString();
    }
}
