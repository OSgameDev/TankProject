using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstBossBullet : MonoBehaviour
{

    [Header("Bullet VARS")]
    private int bulletHealth;
    public float movingSpeed;
    public int bossBulletDamageToTank;
    [Space]

    [Header("GAME OBJ & PARTICLESYSTEM")]
    public ParticleSystem collisionEffect;

    TankPlayerMovement tank;
    camShakeSript cam;

    private AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame

    void Update()
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            aud.Play();
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
            camShakeSript.instance.shakeCam();
            TankPlayerMovement.tank.TankTakeDamage(bossBulletDamageToTank);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "solider")
        {
            collision.gameObject.GetComponent<SoliderEnemyScript>().rocketHitEnemy();
        }
        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }

    }
}
