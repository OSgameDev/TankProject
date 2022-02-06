using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderEnemyScript : MonoBehaviour
{
    #region Insatnce
    public static SoliderEnemyScript solider;
    #endregion
    [Header("Soldier Transforms & GameObjects")]
    
    public GameObject HitEffect;
    public GameObject soliderBullet;
    public GameObject bloodGushEffect;
    public GameObject RedExplosionEffect;
    public GameObject moneyCoin;
    public GameObject bulletOnSoliderEffect;
    public GameObject BloodyBones;
    public GameObject rocketsHitBonesEffect;
    public Transform gunTip;

    [Space]


    [Header("Slolider Variables")]
    public float sloiderFireRate = 20;
    public static int collisionWithTankDamageToTank = 2;
    public static int setEnemyHealth = 13;
    private int enemyHealth = 0;
    
    //static vars
    public static float enemyStartingSpeed = 2.6f;
    public static float MovingSpeed = 2.6f;
    public static float delayBeforeShooting = 1f;

    //priv vars
    private float nextTimeToFire;
    private bool isAive = true;

    //priv unity Compos
    AudioSource aud;
    GameObject bullet;
    Animator soliderAnimator;

    //tank and cam 
    camShakeSript cam;
    TankPlayerMovement tank;

    //priv game objcets
    private GameObject hitEffect;
    private GameObject impact;
    private GameObject effect;
    private GameObject Bones;
    private GameObject death;
    private GameObject bulleT;

    //priv vectors
    private Vector3 pos;
    private Vector3 enemyRocketPos;
    private Vector2 secondCoin;
    //Coin Positions
    Vector3 coinPos;
    Vector3 otherCoinPosition;

    private Vector2 gunTipModifiedPos = Vector2.zero;
    /// <summary>
    /// There are many private vars , The purpos of them is optimising the game , Which is called caching instead of creating a new object each time.
    /// </summary>
    

    public void enemyTakeDamage(int damage)
    {
        enemyHealth -= damage;
        //audio
        hitEnemySound.aud.Play();
        
        if (enemyHealth <= 0)
        {
            //audio 
            TankAnimatorGetter.tankAud.Play();

            //Ground Blood
            effect = Instantiate(bloodGushEffect, transform.position, Quaternion.identity);
            effect.transform.position = new Vector3(transform.position.x, -4.36f, -0.07f);

            //bloody bones
            pos = new Vector3(this.transform.position.x +.4f, this.transform.position.y+3.5f, 0f);
            Bones = Instantiate(BloodyBones, pos, Quaternion.identity);
            Bones.transform.parent = null;

            //coin
            Instantiate(moneyCoin, transform.position, Quaternion.identity);
            if (GameManger.isSpawnTwoCoins)
            {
                secondCoin = new Vector2(this.transform.position.x - .4f, this.transform.position.y);
                Instantiate(moneyCoin,secondCoin, Quaternion.identity);
            }
            //destory
            Destroy(this.gameObject);
        }
    }
    public void rocketHitEnemy()
    {
        //cam shake effect and audio
        camShakeSript.instance.shakeCam();
        TankAnimatorGetter.tankAud.Play();

        //death effect
        death = Instantiate(bloodGushEffect, transform.position, Quaternion.identity);
        death.transform.position = new Vector3(this.transform.position.x, -4.36f, -0.07f);

        //Bones Flying effect
        enemyRocketPos = new Vector3(this.transform.position.x + .4f, this.transform.position.y + 3.5f, 0f);
        GameObject RocketHitBonesEffect = Instantiate(rocketsHitBonesEffect, enemyRocketPos, Quaternion.identity);
        RocketHitBonesEffect.transform.parent = null;

        //coins
        Instantiate(RedExplosionEffect, transform.position, Quaternion.identity);
        Instantiate(moneyCoin, transform.position, Quaternion.identity);

        //spawning Another coin if it is time
        if (GameManger.isSpawnTwoCoins)
        {
            secondCoin = new Vector2(this.transform.position.x - .4f, this.transform.position.y);
            Instantiate(moneyCoin, secondCoin, Quaternion.identity);
        }

        //destory
        Destroy(this.gameObject);
    }
    //All IEnuerators 
    IEnumerator SetBoolFalseDelay()
    {
        yield return new WaitForSeconds(.4f);
        soliderAnimator.SetBool("isShooting", false);
    }
    IEnumerator bulletInstantiateDelay()
    {
        soliderAnimator.SetBool("isShooting", true);

        yield return new WaitForSeconds(.3f);
        //instantiating the Bullet and setting pos
        bullet = Instantiate(soliderBullet, gunTip.position, Quaternion.identity);
        bullet.transform.position = gunTip.position;
        bullet.transform.position += Vector3.left * 4 * Time.deltaTime;

        //audio play
        aud.Play();
        //Shooting Two bullets if true
        if (GameManger.isSoliderShootTwoTimes)
        {
            yield return new WaitForSeconds(.6f);
            soliderAnimator.SetBool("isShooting", true);

            //instantaing the other bullet
            bulleT = Instantiate(soliderBullet, gunTip.position, Quaternion.identity);
            bulleT.transform.position = gunTip.position;
            bulleT.transform.position += Vector3.left * 4 * Time.deltaTime;
            aud.Play();

            //setting shooting animation to false
            StartCoroutine(SetBoolFalseDelay());
        }
        
    }
    IEnumerator soliderShootingTankDelay()
    {
        yield return new WaitForSeconds(delayBeforeShooting);
        ShootPlayer();
    }

    //Methods
    private void Start()
    {
        solider = this;
        enemyHealth = setEnemyHealth;
        soliderAnimator = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<TankPlayerMovement>();
    }

    void ShootPlayer()
    {
        if (Time.time > nextTimeToFire)
        {
            //animation
            StartCoroutine(SetBoolFalseDelay());
            //actual shooting
            StartCoroutine(bulletInstantiateDelay());
            nextTimeToFire = 0;
        }
        nextTimeToFire += Time.time + 1 / sloiderFireRate;
    }

    private void Update()
    {
        //moving solider to the left
        this.transform.position += Vector3.left * MovingSpeed * Time.deltaTime;

        //delay before shooting the tank
        StartCoroutine(soliderShootingTankDelay());

        //making enemies disappear when tank is destoryed
        if (!TankPlayerMovement.isTankAlive)
        {
            this.gameObject.SetActive(false);
        }
        if (TankPlayerMovement.isTankAlive)
        {
            this.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //cam shake / audio / damage
            TankAnimatorGetter.tankAud.Play();
            camShakeSript.instance.shakeCam();
            tank.TankTakeDamage(collisionWithTankDamageToTank);

            //death effect
            death =  Instantiate(bloodGushEffect, transform.position,Quaternion.identity);
            death.transform.position = new Vector3(this.transform.position.x, -4.36f, -0.07f);

            //Explostion effect / coins
            Instantiate(RedExplosionEffect, transform.position, Quaternion.identity);
            Instantiate(moneyCoin, transform.position, Quaternion.identity);
            if (GameManger.isSpawnTwoCoins)
            {
                pos = new Vector2(this.transform.position.x - .3f, this.transform.position.y);
                Instantiate(moneyCoin, pos, Quaternion.identity);
            }

            //destory
            Destroy(this.gameObject);
        }
        if (enemyHealth > 0)
        {
            isAive = true;
        }
        if (enemyHealth >= 0)
        {
            isAive = false;
        }
        if (!isAive)
        {
            //destorying the shot bullet if the solider is dead
            Destroy(bullet);
        }

    }

}
