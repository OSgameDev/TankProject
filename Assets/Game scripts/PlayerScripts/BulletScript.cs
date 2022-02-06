
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float movingSpeed;
    public int sprayBulletDamageToEnemy;
    public int sprayBulletDamageToPlane;
    public int sprayBulletDamageToFirstBoss;
    [Space]

    [Header("Boss ParticleEffects")]
    public ParticleSystem effectOnBoss;//For the boss
    public ParticleSystem bulletColorEffectOnBoss; // For the Boss
    public ParticleSystem onGroundCollisionEffect;

    [Space]
    [Header("Solider ParticleSystemEffects")]
    public ParticleSystem redEffectOnSolider;
    public ParticleSystem blueEffectOnSolider;

    private ParticleSystem effect;//boss
    private ParticleSystem effectColor;//boss

    private ParticleSystem soliderEffect;
    private ParticleSystem soliderBlueEffect;


    private Vector3 finalPosition;
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
                //particle effects
                soliderEffect = Instantiate(redEffectOnSolider, transform.position, Quaternion.identity);
                soliderBlueEffect = Instantiate(blueEffectOnSolider, transform.position, Quaternion.identity);

                hitEnemySound.aud.Play();
                collision.gameObject.GetComponent<SoliderEnemyScript>().enemyTakeDamage(sprayBulletDamageToEnemy);
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("Plane"))
            {
                collision.gameObject.GetComponent<airplaneEnemy>().planeTakeDamage(sprayBulletDamageToPlane);
            }
            if (collision.gameObject.tag == "soliderBullet")
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }

            if (collision.gameObject.layer == 11) // First Boss
            {
                if (firstBossScript.isDead) return;

                bulletHitBoss.aud.Play();
                bulletHitBoss.aud.pitch = Random.Range(1f - .2f, 1 + .2f);
                bulletHitBoss.aud.volume = Random.Range(.7f - .1f, .7f + .1f);
                finalPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                effect = Instantiate(effectOnBoss, finalPosition, Quaternion.identity);
                effectColor = Instantiate(bulletColorEffectOnBoss, finalPosition, Quaternion.identity);
                
                //giving damage
                firstBossScript.boss.bulletTakeDamage(sprayBulletDamageToFirstBoss);

                Destroy(this.gameObject);
            }

            if (collision.gameObject.layer == 6)
            {
                Instantiate(onGroundCollisionEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
