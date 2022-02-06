using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemyScript : MonoBehaviour
{
    [Header("F L O A T S")]
    [Space]
    public float airPlaneMaxTime = 3f;
    public float timeBetweenSecondWaveSpawn;
    public static float maxTime = 1.5f;//the delay between each enemy spawned
    public static float enemyStartingMaxTime = 2.5f;//for re setting
    public static float airplaneSpawnDelayTime = 30;
    public static float timeBeforeSpawningSolider = 4;
    [Space]
    //private floats 
    private float planeTimer;
    private float Timer;
    private bool isSpawnFirstBoss;
    private bool isSpawningOther = false;
    //public static booleans 
    public static bool isTimeToSpawnSolider = false;
    public static bool isTime = false;
    public static bool isSpawningAirPlaneTime = false;
    public static bool isSetActive = false;
    public static bool isFightingBoss = false;

    [Header("G A M E . O B J E C T S")]
    [Space]
    public GameObject firstBoss;
    public GameObject enemyPrefab;
    public GameObject secondEnemyPrefab;
    public GameObject thirdEnemyPrefab;
    public GameObject fouthEnemyPrefab;
    public GameObject airPlane;
    public GameObject Bomb;
    public GameObject bombBlowingEffect;
    public GameObject wavesIncomingHolder;
    public Transform firstBossSpawningPosition;
    [Space]
    [Header("U I ")]
    [Space]
    public Text wavesIncomingText;


    //Caching data vars

    //plane
    private GameObject plane;
    private GameObject bomb;
    private GameObject effect;

    //solider
    private GameObject enemy;

    //Boss
    private GameObject boss;
    private Vector3 spawningPoint;

    private bool isSpawnSecondWave = false;
    private bool isSpawnThirdWave = false;
    private bool isSpawnFourthWave = false;
    IEnumerator timeBeforeSpawning()
    {
        yield return new WaitForSeconds(airplaneSpawnDelayTime);
        isSpawningAirPlaneTime = true;
    }
    IEnumerator timeBeforeActivatingBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            isTime = true;
        }
        
    }

    void spawnAirPlane()
    {
        if (isFightingBoss) return;
        if (planeTimer > airPlaneMaxTime && TankPlayerMovement.isTankAlive && isSpawningAirPlaneTime)
        {
            //Instantiating objs
            plane = Instantiate(airPlane, transform.position, Quaternion.identity);
            bomb = Instantiate(Bomb, transform.position, Quaternion.identity);
            effect = Instantiate(bombBlowingEffect, bomb.transform.position, Quaternion.identity);

            //setting positions
            effect.transform.parent = bomb.transform;
            bomb.transform.parent = plane.transform;
            plane.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 7, 0);
            Bomb.transform.position = plane.transform.position;

            //setting stuff false untill time is ready
            bomb.SetActive(false);
            effect.SetActive(false);
            if (isTime)
            {
                bomb.SetActive(true);
                isTime = false;
            }
            planeTimer = 0;
        }
        planeTimer += Time.deltaTime;
    }
    IEnumerator timeBetweenSecondWave()
    {
        yield return new WaitForSeconds(timeBetweenSecondWaveSpawn);
        isSpawnSecondWave = true;
    }
    private void spawnSolider()
    {
        if (isFightingBoss) return;
        if (Timer > maxTime && TankPlayerMovement.isTankAlive && isTimeToSpawnSolider)
        {
            if (!GameManger.isSpawnSecondSolider && !isSpawningOther)
            {
                if (isSpawningOther) return;
                enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.position = new Vector3(this.transform.position.x, -4.1f, 0);
                Timer = 0;
            }
            if (GameManger.isSpawnSecondSolider && isSpawnSecondWave)
            {
                isSpawningOther = true;
                enemy = Instantiate(secondEnemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.position = new Vector3(this.transform.position.x, - 4.1f, 0);
                Timer = 0;
            }
            if (GameManger.isSpawnThirdSolider)
            {
                GameManger.isSpawnSecondSolider = false;
                enemy = Instantiate(thirdEnemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.position = new Vector3(this.transform.position.x, - 4.1f, 0);
                Timer = 0;
            }
            if (GameManger.isSpawnFourthSolider)
            {
                GameManger.isSpawnThirdSolider = false;
                enemy = Instantiate(fouthEnemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.position = new Vector3(this.transform.position.x, -4.1f, 0);
                Timer = 0;
            }

        }
        Timer += Time.deltaTime;
    }
    IEnumerator onBossDeathDelay()
    {
        yield return new WaitForSeconds(1.4f);
        isSpawnFirstBoss = true;
        isFightingBoss = false;
    }
    private void spawnFirstBoss()
    {
        if (!isFightingBoss && GameManger.isSpawnSecondSolider && !isSpawnFirstBoss && !firstBossScript.isDead)
        {
            rightColliderController.collider.isTrigger = true;
            boss = Instantiate(firstBoss, firstBossSpawningPosition.position, Quaternion.identity);
            isFightingBoss = true;
            if (firstBossScript.isDead)
            {
                StartCoroutine(onBossDeathDelay());
            }
        }
    }
    void Update()
    {
        StartCoroutine(timeBeforeSpawning());
        StartCoroutine(timeBeforeActivatingBomb());
        spawnAirPlane();
        spawnSolider();
        spawnFirstBoss();
        StartCoroutine(timeBetweenSecondWave());
    }
}
