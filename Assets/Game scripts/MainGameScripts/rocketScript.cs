using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    [Header("Bullet Variables")]

    public ParticleSystem bossBulletImpact;
    public ParticleSystem rocketEffect;

    public static bool playParticleEffect;
    public float movingSpeed;
    public int damageToFirstBoss;
    public int sprayBulletDamageToEnemy;
    public int sprayBulletDamageToPlane;

    void Update()
    {
        transform.position += Vector3.right * movingSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("solider"))
            {
                TankAnimatorGetter.tankAud.Play();
                collision.gameObject.GetComponent<SoliderEnemyScript>().rocketHitEnemy();
                Destroy(this.gameObject, 3f);
            }
            if (collision.gameObject.CompareTag("Plane"))
            {
                collision.gameObject.GetComponent<airplaneEnemy>().planeTakeDamage(sprayBulletDamageToPlane);
            }
            if (collision.gameObject.tag == "soliderBullet")
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.layer == 11)
            {
                rocketHitBossSound.aud.Play();
                firstBossScript.boss.rocketTakeDamage(damageToFirstBoss);
                Instantiate(bossBulletImpact, transform.position, Quaternion.identity);
                Instantiate(rocketEffect, transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
            if (collision.gameObject.layer == 6)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
