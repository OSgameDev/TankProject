using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankPlayerMovement : MonoBehaviour
{
    #region Instance
    public static TankPlayerMovement tank;
    #endregion

    //Player moving variables
    [Header("Player Variables")]
    [Space]

    //other
    public ParticleSystem bulletMuzzleFlash;
    public ParticleSystem rocketMuzzleFlash;

    //movement JoyStick
    public Joystick joystick;

    //ints
    public int tankRocketDamageToSolider;
    public static int tankRocketCapacity = 5;

    //Public Floats
    public static float MovementSpeed = 7;
    public float JumpForce;
    public float shootingAnimtionSetFalseDelay;
    public float rocketShakeDuration;
    public float rocketShakeMagnitude;

    //Vibration
    public long rocketShootDeviceVibrationDuration;

    //public static floats
    public static float tankHealth = 200;
    public static float CurrentHealth;

    //public static bools
    public static bool isTankAlive = true;
    public static bool isTouching = false;

    //priv
    private bool isPlayingHitAnimation = false;
    [Space]
    
    //private compos
    private Rigidbody2D Rb;
    private Vector2 MovementDirection;
    private AudioSource TankShootingSound;

    [Header("Fire Rates")]
    [Space]
    public static float rocketFireRate = 1;
    public static float sprayShootFireRate = 3;

    //fire rate nextTimes privateFloats
    private float horizontal;
    private float nextTimeToFire = 0;
    private float sprayNextTimeToFire = 0;
    private float rotationAnglePos;
    private float zRotation;
    private Vector3 dampen;
    [Space]

    [Space]

    [Header("Transforms")]
    [Space]
    public Transform TankWheels;
    public Transform tankSprayFiringpos;
    public Transform TankFiringPosition;
    public Transform secondFiringPos;
    public Transform thirdFiringPos;

    public static Transform thisTank;
    [Space]

    [Header("Game Objects")]
    [Space]
    public GameObject BulletPrefab;
    public GameObject muzzleFlash;
    public GameObject deathPanelHolder;
    public GameObject rocket;
    //public GameObject crosshair;
    [Space]

    [Header("LayerMasks")]
    [Space]
    public LayerMask groundLayer;
    public LayerMask Enemies;
    [Space]


    [Header("UI Elements")]
    public Text rocketsCapacityText;

    //other
    private static bool isGrounded;

    //touch spray variables
    Touch touch;
    Vector3 touchPos;
    Vector2 finalPos;

    //tank flipping Fix
    private GameObject shotRocket;
    private GameObject Bullet;
    private Camera mainCamera;

 

    /// <summary>
    /// purpos of this code : Setting Stage of upgrades , Moving , Attacking, Managment of player
    /// </summary>
    
    private void settingTank()
    {
        saveAndloadsystem.LoadPlayerData();

        //Spray Fire Rate 
        switch (MainMenuManager.stageOfFireRate)
        {
            case 1:
                sprayShootFireRate = 4;
                break;
            case 2:
                sprayShootFireRate = 5;
                break;
            case 3:
                sprayShootFireRate = 6;
                break;
            case 4:
                sprayShootFireRate = 7;
                break;
            case 5:
                sprayShootFireRate = 8;
                break;
            case 6:
                sprayShootFireRate = 9;
                break;
            case 7:
                sprayShootFireRate = 10;
                break;
            case 8:
                sprayShootFireRate = 11;
                break;
            case 9:
                sprayShootFireRate = 12;
                break;
            case 10:
                sprayShootFireRate = 13;
                break;
            case 11:
                sprayShootFireRate = 14;
                break;
            case 12:
                sprayShootFireRate = 15;
                break;
            case 13:    
                sprayShootFireRate = 16;
                break;
            default:
                sprayShootFireRate = 3;
                break;
        }

        //movementSpeed
        switch (MainMenuManager.stageOfSpeed)
        {
            case 1:
                MovementSpeed = 8;
                break;
            case 2:
                MovementSpeed = 9;
                break;
            case 3:
                MovementSpeed = 10;
                break;
            case 4:
                MovementSpeed = 11;
                break;
            case 5:
                MovementSpeed = 12;
                break;
            default:
                MovementSpeed = 7;
                break;
        }

        //health
        switch (MainMenuManager.stageOfHealth)
        {
            case 1:
                tankHealth = 150;
                break;
            case 2:
                tankHealth = 200;
                break;
            case 3:
                tankHealth = 300;
                break;
            case 4:
                tankHealth = 400;
                break;
            case 5:
                tankHealth = 500;
                break;
            default:
                tankHealth = 100;
                break;
        }

        //rocket capacity
        switch (MainMenuManager.stageOfRocketCapacity)
        {
            case 1:
                tankRocketCapacity = 6;
                break;
            case 2:
                tankRocketCapacity = 8;
                break;
            case 3:
                tankRocketCapacity = 10;
                break;
            case 4:
                tankRocketCapacity = 12;
                break;
            case 5:
                tankRocketCapacity = 20;
                break;
            default:
                tankRocketCapacity = 5;
                break;
        }

        //rocket fire rate 

        switch (MainMenuManager.stageOfRocketFireRate)
        {
            case 1:
                rocketFireRate = 2;
                break;
            case 2:
                rocketFireRate = 3.5f;
                break;
            case 3:
                rocketFireRate = 4.5f;
                break;
            case 4:
                rocketFireRate = 5.5f;
                break;
            case 5:
                rocketFireRate = 6.5f;
                break;
            default:
                rocketFireRate = 1;
                break;
        }
    }
    private void Awake()
    {
        settingTank();
    }
    void Start()
    {
        //camera instance
        mainCamera = Camera.main;

        //setting the instance
        tank = this;


        //tank referance
        thisTank = this.transform;

        //getting compos
        Rb = GetComponent<Rigidbody2D>();
        TankShootingSound = GetComponent<AudioSource>();

        //setting the health to max health
        CurrentHealth = tankHealth;
        isTankAlive = true;
    }
    IEnumerator setHitAnimationFalse()
    {
        if (isPlayingHitAnimation)
        {
            yield return new WaitForSeconds(0.1f);
            TankAnimatorGetter.TankAnimator.SetBool("isHit", false);
            isPlayingHitAnimation = false;
        }

    }
    IEnumerator shootingAnimationFalseDelay()
    {
        yield return new WaitForSeconds(shootingAnimtionSetFalseDelay);
        TankAnimatorGetter.TankAnimator.SetBool("isShooting", false);
    }

    private void Movement()
    {
        horizontal = joystick.Horizontal * MovementSpeed * Time.deltaTime;
        MovementDirection = new Vector2(horizontal,0);
        if (isTankAlive)
        {
            Rb.velocity += MovementDirection;
        }
    }
    private void joystickJumping()
    {
        isGrounded = Physics2D.OverlapCircle(TankWheels.position, 0.1f , groundLayer);//to check if the player is grounded
        if (isGrounded && isTankAlive && joystick.Vertical >= 0.5f)
        {
            Rb.velocity = Vector2.up * JumpForce;
        }
    }

    public void rocketShooting()
    {
        if (tankRocketCapacity <= 0) return;
        if (firiingModeControl.isPaused) return;
        if (Time.time >= nextTimeToFire && isTankAlive)
        {

            //muzzleFlash
            rocketMuzzleFlash.Play();

            tankRocketCapacity--;

            nextTimeToFire = Time.time + 1 / rocketFireRate;
            //aniamtion
            TankAnimatorGetter.TankAnimator.SetBool("isShooting", true);

            //Camera shake
            camShakeSript.instance.shakeCam();

            //audio
            TankShootingSound.Play();

            //setting shooting animation to false
            StartCoroutine(shootingAnimationFalseDelay());

            dampen = new Vector3(5f, 5f, 0f); // raw position if not correct , so i used dampening to make it fit the screen.
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos += dampen;

            finalPos = TankFiringPosition.position + touchPos;
            finalPos.Normalize();

            //Actual shooting
            shotRocket = Instantiate(rocket, TankFiringPosition.position, Quaternion.identity);
            shotRocket.GetComponent<Rigidbody2D>().velocity = finalPos;
        }
    }

    private void touchInputAR()
    {
        //Vector2 touchPos;   
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }
    }
    
    public void TankTakeDamage(int damage)
    {
        CurrentHealth -= damage;
        TankAnimatorGetter.TankAnimator.SetBool("isHit", true);
        isPlayingHitAnimation = true;
        StartCoroutine(setHitAnimationFalse());
    }

    public void tankDeath()
    {
        if (CurrentHealth <= 0)
        {
            isTankAlive = false;
            TankAnimatorGetter.TankAnimator.SetBool("isDestroyed", true);
        }
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

     private void tankManagment()
    {
        if (isTankAlive)
        {
            TankAnimatorGetter.TankAnimator.SetBool("isDestroyed", false);
            AliveComponentsGetter.controllsPanel.SetActive(true);
            deathPanelHolder.SetActive(false);
            //Time.timeScale = 1;
        }
    }
    /// <summary>
    /// Touch shooting is made by:  Getting the touch phase and poistion . If the phase has ended it will stop , the position than will be translated to world points and into a vector 2 
    /// THe vector 2 is used to make it the bullet point to go , And than it is looped by using a bool that will be ture when phase has started or moved and false when ended , Than i used invoke
    /// reapting to make it loop when the bool is true.
    /// </summary>
    private void sprayShoot()
    {
        dampen = new Vector3(5f, 5f, 0f);//dampening values that will be added to the touch position vector 
        touchPos = mainCamera.ScreenToWorldPoint(touch.position);//getting the touch position
        touchPos += dampen;//dampening the touch position to fit the screen

        if (touchPos.x <= 1.1f) return;//returning when the pisition of the toucb is to the left side 
        if (firiingModeControl.isPaused) return;
        if (Time.time > sprayNextTimeToFire && firiingModeControl.isUsingSprayMode)//fire rate 
        {
            //muzzle flash
            bulletMuzzleFlash.Play();

            sprayNextTimeToFire = Time.time + 1 / sprayShootFireRate;//fire rate
            //sounds
            sprayFireSound.aud.Play();

            //positions for shooting
            finalPos = tankSprayFiringpos.position + touchPos;
            finalPos.Normalize();

            rotationAnglePos = Mathf.Atan2(touchPos.x, touchPos.y) * Mathf.Rad2Deg;

            //physical shooting
            Bullet = Instantiate(BulletPrefab, tankSprayFiringpos.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().velocity = finalPos * 2;
            tankSprayFiringpos.rotation = Quaternion.Euler(0, rotationAnglePos, 0);
            Bullet.transform.rotation = Quaternion.Euler(rotationAnglePos + 270, 0, 0);

            //second bullet implementation when is bought

            //third bullet implementation when is bought

        }
        if (!firiingModeControl.isUsingSprayMode)
        {
            rocketShooting();
        }
    }

    private void sprayManagment()
    {
        if (isTouching && !buttonCustomScript.isPressed && isTankAlive)
        {
            InvokeRepeating("sprayShoot", 0, 0.03f);
        }
        if (!isTouching)
        {
            CancelInvoke("sprayShoot");
        }
    }

    // Update is called once per frame

    void Update()
    {
        //UI rocket capacity update
        rocketsCapacityText.text = tankRocketCapacity.ToString();

        //methods
        touchInputAR();
        sprayManagment();
        Movement();
        tankDeath();
        tankManagment();
        joystickJumping();
    }
}
