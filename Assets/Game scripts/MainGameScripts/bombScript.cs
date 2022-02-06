using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class bombScript : MonoBehaviour
{
    
    public int bombDamageToPlayer;
    public float timeBeforeDestroyingThis;
    private bool stopDamagin = false;

    public GameObject explosionEffect;
    public Color explosionColor;
    public UnityEngine.Experimental.Rendering.Universal.Light2D bombLight;

    private AudioSource aud;
    TankPlayerMovement tank;
    camShakeSript cam;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<TankPlayerMovement>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShakeSript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && !stopDamagin)
        {
            aud.Stop();
            bombExplosionSound.aud.Play();
            tank.TankTakeDamage(bombDamageToPlayer);
            cam.shakeCam();
            explosionEffect.SetActive(true);
            bombLight.color = explosionColor;
            stopDamagin = true;
            Destroy(this.gameObject,.75f);
        }
    }
           
}
