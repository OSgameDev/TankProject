using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    //testing
    public Camera focusCamera;
    public Camera UiCamera;

    public GameObject focusCameraVolume;
    public GameObject UiCameraVolume;

    public void settingsButton()
    {

    }

    //testing end

    //loading
    public Text loadingText;

    //public InputField PlayerNameInput;
    public Text playerMoneyText;
    public Text upgradeShopButtonText;
    public  AudioSource aud;


    //Button colors depending on price and money
    public Color enoughMoneyColor;
    public Color notEnoughMoneyColor;


    [Space]
    [Header("Shop Buttons")]
    //Upgrade shop buttons
    public Button health;
    public Button autoFireRate;
    public Button speed;
    public Button capacity;
    public Button rocketFireRate;

    [Space]
    [Header("Shop Sliders")]
    //upgrade shop sliders
    public Slider sprayFireRateSlider;
    public Text sprayFireRateButtonText;
    public Text sprayFireRateText;
    public Text fireRatePriceText;

    [Space]
    [Header("Health Upgrade vars")]
    public Slider healthSlider;
    public Text healthButtonText;
    public Text healthText;
    public Text healthPriceText;

    [Space]
    [Header("Movement Speed Upgrade vars")]
    public Slider movementSpeedSlider;
    public Text speedButtontext;
    public Text movementSpeedText;
    public Text movementPriceText;

    [Space]
    [Header("Rocket Capacity Upgrade vars")]
    public Slider rocketCapacitySlider;
    public Text capacityButtonText;
    public Text rocketCapacityText;
    public Text capacityPriceText;

    [Space]
    [Header("Rocket Fire Rate Upgrade vars")]
    public Slider rocektFireRateSlider;
    public Text rocketFireRateButtonText;
    public Text rocketFireRateText;
    public Text rocketFireRatePriceText;

    [Space]
    [Header("Shop Prices")]
    public int fireRatePrice;
    public int rocketCapacityPrice;
    public int tankHealthPrice;
    public int movementSpeedPrice;
    public int rocketFireRatePrice;

    //bools for saving 
    public static int stageOfFireRate;
    public static int stageOfHealth;
    public static int stageOfRocketCapacity;
    public static int stageOfSpeed;
    public static int stageOfRocketFireRate;

    //loading Scene operation caching
    AsyncOperation asyncLoad;
    private float loadingProgress;
    private void Awake()
    {
        //loading data 
        saveAndloadsystem.LoadPlayerData();

        //Setting the values
        sprayFireRateSlider.value = stageOfFireRate;
        sprayFireRateText.text = stageOfFireRate.ToString();

        healthSlider.value = stageOfHealth;
        healthText.text = stageOfHealth.ToString();

        movementSpeedSlider.value = stageOfSpeed;
        movementSpeedText.text = stageOfSpeed.ToString();

        rocketCapacitySlider.value = stageOfRocketCapacity;
        rocketCapacityText.text = stageOfRocketCapacity.ToString();

        rocektFireRateSlider.value = stageOfRocketFireRate;
        rocketFireRateText.text = stageOfRocketFireRate.ToString();

        //setting time scale
        Time.timeScale = 1;
    }

    private void buttonManagment()
    {
        //health

        if (playerCoinManagment.playerMoney < tankHealthPrice)
        {
            health.image.color = notEnoughMoneyColor;
        }
        else
        {
            health.image.color = enoughMoneyColor;
        }

        // spray fire rate 

        if (playerCoinManagment.playerMoney < fireRatePrice)
        {
            autoFireRate.image.color = notEnoughMoneyColor;
        }
        else
        {
            autoFireRate.image.color = enoughMoneyColor;
        }

        //movement speed

        if (playerCoinManagment.playerMoney < movementSpeedPrice)
        {
            speed.image.color = notEnoughMoneyColor;
        }
        else
        {
            speed.image.color = enoughMoneyColor;
        }

        //Rocket capacity
        if (playerCoinManagment.playerMoney < rocketCapacityPrice)
        {
            capacity.image.color = notEnoughMoneyColor;
        }
        else
        {
            capacity.image.color = enoughMoneyColor;
        }

        //rocket fire rate 
        if (playerCoinManagment.playerMoney < rocketFireRatePrice)
        {
            rocketFireRate.image.color = notEnoughMoneyColor;
        }
        else
        {
            rocketFireRate.image.color = enoughMoneyColor;
        }
    }
    private void maxOutTracking()
    {
        // fire rate 
        if (stageOfFireRate == 10)
        {
            sprayFireRateButtonText.text = "m a x";
            sprayFireRateButtonText.fontSize = 38;
            autoFireRate.image.color = enoughMoneyColor;
            autoFireRate.interactable = false;
        }

        //movement speed 
        if (stageOfSpeed == 5)
        {
            speedButtontext.text = "m a x";
            speedButtontext.fontSize = 38;
            speed.image.color = enoughMoneyColor;
            speed.interactable = false;
        }

        //Tank Health
        if (stageOfHealth == 5)
        {
            healthButtonText.text = "m a x";
            healthButtonText.fontSize = 38;
            health.interactable = false;
        }

        //Rocket Fire Rate 
        if (stageOfRocketFireRate == 5)
        {
            rocketFireRateButtonText.text = "m a x";
            rocketFireRateButtonText.fontSize = 38;
            rocketFireRate.interactable = false;
        }

        // Rocket Capacity
        if (stageOfRocketCapacity == 5)
        {
            capacityButtonText.text = "m a x";
            capacityButtonText.fontSize = 38;
            capacity.interactable = false;
        }
    }
    void updatePrice()
    {
        //updating the prices on the shop while purchasing
        fireRatePriceText.text = fireRatePrice.ToString();
        healthPriceText.text = tankHealthPrice.ToString();
        capacityPriceText.text = rocketCapacityPrice.ToString();
        rocketFireRatePriceText.text = rocketFireRatePrice.ToString();
        movementPriceText.text = movementSpeedPrice.ToString();
    }
    private void Update()
    {
        playerMoneyText.text = " " + playerCoinManagment.playerMoney.ToString();

        /*GameManger.PlayerNameFromMainMenu = PlayerNameInput.text;
        if (PlayerNameInput.text == "")
        {
            GameManger.PlayerNameFromMainMenu = "T A N K";
        }*/

        //keeping track of prices and player money

        updatePrice();
        buttonManagment();
        maxOutTracking();

        //update values
        sprayFireRateSlider.value = stageOfFireRate;
        sprayFireRateText.text = stageOfFireRate.ToString();

        healthSlider.value = stageOfHealth;
        healthText.text = stageOfHealth.ToString();

        movementSpeedSlider.value = stageOfSpeed;
        movementSpeedText.text = stageOfSpeed.ToString();

        rocketCapacitySlider.value = stageOfRocketCapacity;
        rocketCapacityText.text = stageOfRocketCapacity.ToString();

        rocektFireRateSlider.value = stageOfRocketFireRate;
        rocketFireRateText.text = stageOfRocketFireRate.ToString();
    }
    IEnumerator LevelLoaderAnimation()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    IEnumerator GameSceneLoad()
    {
        yield return new WaitForSeconds(1);
        asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loadingProgress = Mathf.Round(asyncLoad.progress);
            loadingText.text = "LOADING " + loadingProgress * 100 + "%";
            yield return null;
        }
    }
    public void PlayButton()
    {
        //Playering Audio/ re setting time scale
        aud.Play();
        Time.timeScale = 1;

        //re setting In Game variables
        AdsManager.isWatchedAdBefore = false;
        LevelLoader.anim.SetBool("start", true);
        SpawnEnemyScript.maxTime = SpawnEnemyScript.enemyStartingMaxTime;
        SoliderEnemyScript.MovingSpeed = SoliderEnemyScript.enemyStartingSpeed;
        SpawnEnemyScript.isSpawningAirPlaneTime = false;
        SpawnEnemyScript.isSetActive = false;

        //re setting boss var
        firstBossScript.isDead = false;

        //GameManager Values res set 
        GameManger.isSoliderShootTwoTimes = false;
        GameManger.isSpawnSecondSolider = false;
        GameManger.isSpawnThirdSolider = false;
        GameManger.isSpawnFourthSolider = false;
        GameManger.setWavesTextTrue = false;
        GameManger.isSpawnTwoCoins = false;

        //checking if last game boss wasn't killed
        if (SpawnEnemyScript.isFightingBoss && !firstBossScript.isDead)
        {
            SpawnEnemyScript.isFightingBoss = false;
        }

        //scene fade animtion setting off
        StartCoroutine(GameSceneLoad());
    }

    
    public void upgradeFireRate()
    {
        if (playerCoinManagment.playerMoney < fireRatePrice) return;
        else
        {
            playerCoinManagment.playerMoney -= fireRatePrice;
            stageOfFireRate += 1;
            fireRatePrice += fireRatePrice;
            upgradeSound.aud.Play();
            saveAndloadsystem.SavePlayerData();
        }
        
    }
    public void upgradeHealth()
    {
        if (playerCoinManagment.playerMoney < tankHealthPrice) return;

        else
        {
            Debug.Log("StageOfHealth: " + stageOfHealth);
            playerCoinManagment.playerMoney -= tankHealthPrice;
            stageOfHealth += 1;
            tankHealthPrice += 1000;
            upgradeSound.aud.Play();
            saveAndloadsystem.SavePlayerData();
        }
    }
    public void upgraderocketCapacity()
    {
        if (playerCoinManagment.playerMoney < rocketCapacityPrice) return;
        else
        {
            playerCoinManagment.playerMoney -= rocketCapacityPrice;
            stageOfRocketCapacity += 1;
            rocketCapacityPrice += 1000;
            upgradeSound.aud.Play();
            saveAndloadsystem.SavePlayerData();
        }

    }
    public void upgradeRocketFireRate()
    {
        if (playerCoinManagment.playerMoney < rocketFireRatePrice) return;
        else
        {
            playerCoinManagment.playerMoney -= rocketFireRatePrice;
            stageOfRocketFireRate += 1;
            rocketFireRatePrice += 1000;
            upgradeSound.aud.Play();
            saveAndloadsystem.SavePlayerData();
        }
    }
    public void upgradeMovementSpeed()
    {
        if (playerCoinManagment.playerMoney < movementSpeedPrice) return;
        else
        {
            playerCoinManagment.playerMoney -= movementSpeedPrice;
            stageOfSpeed += 1;
            movementSpeedPrice += 1000;
            upgradeSound.aud.Play();
            saveAndloadsystem.SavePlayerData();
        }
        
    }

    public void QuitButton()
    {
        Debug.Log("Game closed by user");
        Application.Quit();
    }
}
