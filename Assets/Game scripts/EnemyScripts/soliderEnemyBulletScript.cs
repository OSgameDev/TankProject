using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderEnemyBulletScript : MonoBehaviour
{
    public static  int soliderDamageToTank = 4;
    public static float bulletMovingSpeed = 6;
    TankPlayerMovement tank;
    camShakeSript cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            bulletHitTankSound.aud.Play();
            tank.TankTakeDamage(soliderDamageToTank);
            cam.shakeCam();
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<TankPlayerMovement>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShakeSript>();
    }
    private void Update()
    {
        transform.position += Vector3.left * bulletMovingSpeed * Time.deltaTime;
    }
}
