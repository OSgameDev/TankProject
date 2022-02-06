using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour
{
    [Header("Game Difficulty Increase Variables")]
    public float TimeBeforeFirstIncrease;
    public float TimeBeforeSecondIncrease;
    public float TimeBeforeThirdIncrease;
    public float TimeBeforeFourtIncrease;
    public float TimeBeforeFifthIncrease;
    public float TimeBeforeSixthIncrease;
    public float TimeBeforeSeventhIncrease;
    public float TimeBeforeeighthIncreasse;


    private float deltaTimeTimer;
    private float spawnSoliderTime;
    private float airplaneTime;

    [Space]
    [Header("TEXTS")]
    public Text PlayerName;
    public Text TankHealthDisplayText;
    [Space]

    [Header("Game Objects")]
    public GameObject firstBoss;
    public GameObject deathScreenComponenetsHolder;
    public GameObject whenAliveComponents;
    public GameObject wavesIncomingHolder;
    public Transform spawningArea;
    public Text wavesIncomingText;
    //others
    public static bool isSpawnSecondSolider = false;
    public static bool isSpawnThirdSolider = false;
    public static bool isSpawnFourthSolider = false;
    public static bool setWavesTextTrue = false;
    public static bool isSoliderShootTwoTimes = false;
    public static bool isSpawnTwoCoins = false;
    public static bool isBossSpawned;
    public static string PlayerNameFromMainMenu = "T A N K";


    public static Vector3 SpawningPosition = new Vector3(-7.195f, -4.128f, -182.778f);

    //others
    camShakeSript cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShakeSript>();
        airplaneTime = SpawnEnemyScript.airplaneSpawnDelayTime;
        spawnSoliderTime = SpawnEnemyScript.timeBeforeSpawningSolider;
        TankPlayerMovement.CurrentHealth = TankPlayerMovement.tankHealth;
        TankPlayerMovement.isTankAlive = true;

    }
    IEnumerator settingFalse()
    {
        yield return new WaitForSeconds(4);
        wavesIncomingHolder.SetActive(false);
        setWavesTextTrue = false;
    }
    private void IncreaseingGameDiffeculty()
    {
        deltaTimeTimer += Time.deltaTime;
        if (!TankPlayerMovement.isTankAlive && AdsManager.isWatchedAdBefore) return;
        if (Mathf.Round(deltaTimeTimer) == spawnSoliderTime)
        {
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "FIRST IS WAVE INBOUND GET READY.";
                setWavesTextTrue = true;
                wavesTextSound.aud.Play();
                SpawnEnemyScript.isTimeToSpawnSolider = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }

        if (Mathf.Round(deltaTimeTimer) == airplaneTime)
        {
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "ENEMY AIRPLANES ARE INBROUND.";
                setWavesTextTrue = true;
                wavesTextSound.aud.Play();
                SpawnEnemyScript.isSpawningAirPlaneTime = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }

        if (Mathf.Round(deltaTimeTimer) == TimeBeforeFirstIncrease)
        {
            SpawnEnemyScript.maxTime = 1f;
            SoliderEnemyScript.MovingSpeed = 2.9f;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "SECOND IS WAVE INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeSecondIncrease)
        {
            SoliderEnemyScript.setEnemyHealth = 20;
            soliderEnemyBulletScript.soliderDamageToTank = 5;
            SpawnEnemyScript.maxTime = .9f;
            SoliderEnemyScript.MovingSpeed = 3f;
            if (!setWavesTextTrue)
            {
                isSpawnSecondSolider = true;
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "SHERMAN BOSS IS INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeThirdIncrease)
        {
            SpawnEnemyScript.maxTime = .8f;
            SoliderEnemyScript.MovingSpeed = 3.1f;
            soliderEnemyBulletScript.bulletMovingSpeed = 6.5f;
            isSpawnTwoCoins = true;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "FORTH IS WAVE INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeFourtIncrease)
        {
            soliderEnemyBulletScript.soliderDamageToTank = 8;
            SoliderEnemyScript.setEnemyHealth = 35;
            SpawnEnemyScript.maxTime = .7f;
            SoliderEnemyScript.MovingSpeed = 3.2f;
            soliderEnemyBulletScript.bulletMovingSpeed = 7f;
            isSpawnThirdSolider = true;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "FIFTH WAVE IS INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeSixthIncrease)
        {
            SpawnEnemyScript.maxTime = .6f;
            SoliderEnemyScript.MovingSpeed = 3.3f;
            soliderEnemyBulletScript.bulletMovingSpeed = 7.5f;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "SIXTH WAVE IS INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeSeventhIncrease)
        {
            SpawnEnemyScript.maxTime = .5f;
            SoliderEnemyScript.MovingSpeed = 3.4f;
            soliderEnemyBulletScript.bulletMovingSpeed = 8f;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "SEVENTH WAVE IS INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }
        if (Mathf.Round(deltaTimeTimer) == TimeBeforeeighthIncreasse)
        {
            isSpawnFourthSolider = true;
            soliderEnemyBulletScript.soliderDamageToTank = 10;
            SoliderEnemyScript.setEnemyHealth = 45;
            SpawnEnemyScript.maxTime = .3f;
            SoliderEnemyScript.MovingSpeed = 3.5f;
            soliderEnemyBulletScript.bulletMovingSpeed = 8f;
            if (!setWavesTextTrue)
            {
                wavesIncomingHolder.SetActive(true);
                wavesIncomingText.text = "EIGHTH WAVE IS INBOUND GET READY.";
                wavesTextSound.aud.Play();
                setWavesTextTrue = true;
            }
            if (setWavesTextTrue)
            {
                StartCoroutine(settingFalse());
            }
        }

    }
    // Update is called once per frame
    private void tankDeathActions()
    {
        if (!TankPlayerMovement.isTankAlive)
        {
            deathScreenComponenetsHolder.SetActive(true);
            whenAliveComponents.SetActive(false);
        }
        if (mainGameUIManager.isSucsses)
        {
            mainGameUIManager.isSucsses = false;
            Debug.Log("TimerScale: " + Time.timeScale);
        }
    }
    IEnumerator delay() // no use , if still not , DELETE!
    {
        yield return new WaitForSeconds(2);
        //ScrollingBackground.scrollingSpeed = 0.097f;
        SoliderEnemyScript.MovingSpeed = 3.3f;
        SpawnEnemyScript.maxTime = 1.6f;
        SoliderEnemyScript.delayBeforeShooting = .5f;
    }
    void Update()
    {
        PlayerName.text = PlayerNameFromMainMenu;
        TankHealthDisplayText.text = TankPlayerMovement.CurrentHealth + " / " + TankPlayerMovement.tankHealth;
        tankDeathActions();
        IncreaseingGameDiffeculty();
        //StartCoroutine(dealy());
    }
}
