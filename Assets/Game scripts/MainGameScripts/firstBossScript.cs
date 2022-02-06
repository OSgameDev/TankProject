using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class firstBossScript : MonoBehaviour
{
    #region Instance
    public static firstBossScript boss;

    #endregion

    private bool isReachedPoint = false;

    [Header("GAME OBJS AND TRANSFORMS")]
    public GameObject solider;
    public GameObject bulletPrefab;
    public GameObject coins;
    public Transform gunTip;
    public ParticleSystem muzzleFlash;
    [Space]

    [Header("BOSS VARIABLES")]
    public int bossHealth;
    private int currentHealth;
    public float fireRate;
    public float movingSpeed;
    public int collisionDamage;
    [Space]

    [Header("UI Elements")]
    private Slider bossHealthSlider;
    private Text bossHealthText;

    //private vars
    private camShakeSript cam;
    private Animator anim;
    private SpriteRenderer bossSpriteRenderer;

    private float timer;


    private float spawningSoliderTimer;
    private float spawningSoliderMaxTime = 3.5f;
    
    public static bool isDead = false;

    //Caching vars , Game objects 
    private GameObject rocketBullet;
    // Start is called before the first frame update
    private void Awake()
    {
        bossHealthSlider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        bossHealthText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();

        bossInfo_Animator.anim.SetBool("fightStarted", true);
    }
    void Start()
    {
        boss = this;
        currentHealth = bossHealth;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShakeSript>();
        bossSpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    IEnumerator setShootingAnimationFalse()
    {
        yield return new WaitForSeconds(.7f);
        anim.SetBool("isAttacking", false);
    }
    private void shootingPlayer()
    {
        if (isDead) return;
        if (timer > fireRate && TankPlayerMovement.isTankAlive)
        {
            anim.SetBool("isAttacking", true);
            muzzleFlash.Play();
            cam.shakeCam();
            rocketBullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
            StartCoroutine(setShootingAnimationFalse());
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void bulletTakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0; //seting it to 0 so it doesn't show negative numbers if it is

            isDead = true; //Boss is dead var

            anim.SetBool("isAttacking", false);//setting attack animation off incase it was on the second it died
            anim.SetBool("isDestroyed", true);//destory animation play

            SpawnEnemyScript.isFightingBoss = false;//so the soliders show up again

            coins.SetActive(true);//setting the reward active
            coins.transform.parent = null;//so doesn't be affected by this object

            rightColliderController.collider.isTrigger = false;

            bossInfo_Animator.anim.SetBool("fightStarted", false);

            Destroy(this.gameObject,4f);//destory after dead animation
        }
    }
    public void rocketTakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0; //seting it to 0 so it doesn't show negative numbers if it was 

            isDead = true; //Boss is dead var

            anim.SetBool("isAttacking", false);//setting attack animation off incase it was on the second it died
            anim.SetBool("isDestroyed", true);//destory animation play

            SpawnEnemyScript.isFightingBoss = false;//so the soliders show up again

            coins.SetActive(true);//setting the reward active
            coins.transform.parent = null;//so doesn't be affected by this object

            rightColliderController.collider.isTrigger = false;

            bossInfo_Animator.anim.SetBool("fightStarted", false);

            Destroy(this.gameObject, 1.4f);//destory after dead animation
        }
    }
    private void bossRage()
    {
        if (currentHealth <= 100)
        {
            anim.SetBool("isRage", true);
            //Spawn Enemies: 
            if (spawningSoliderTimer > spawningSoliderMaxTime)
            {
                var spawningP = new Vector2(transform.position.x -2.5f , transform.position.y);
                var spawnedEnemy = Instantiate(solider,spawningP,Quaternion.identity);
                spawningSoliderTimer = 0;
            }
        }
        spawningSoliderTimer += Time.deltaTime;

    }
    void moveToFightingPoint()
    {
        if (isReachedPoint) return;
        this.transform.position += Vector3.left * movingSpeed * Time.deltaTime;
        if (transform.position.x <= 6.8f)
        {
            isReachedPoint = true;
        }
    }

    //Removing the boss info when the tank is dead , Returning it when the tank is alive 
    private void onTankDeathHandlSlider()
    {
        if (TankPlayerMovement.isTankAlive && bossInfo_Animator.canvasG.alpha > 0)
        {
            bossInfo_Animator.canvasG.alpha = 0;
        }
        else
        {
            bossInfo_Animator.canvasG.alpha = 1;
        }
    }//return the function to update when fixed !
    void Update()
    {
        #region Updating UI
        bossHealthSlider.minValue = 0;
        bossHealthSlider.maxValue = bossHealth;
        bossHealthSlider.value = currentHealth;
        bossHealthText.text = currentHealth.ToString() + "/" + bossHealth.ToString();
        #endregion
        bossRage();
        shootingPlayer();
        moveToFightingPoint();
        //onTankDeathHandlSlider();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            TankPlayerMovement.tank.TankTakeDamage(collisionDamage);
        }
        if (collision.gameObject.layer == 7 && collision.gameObject.tag == "solider")
        {
            SoliderEnemyScript.solider.rocketHitEnemy();
        }
    }
}
