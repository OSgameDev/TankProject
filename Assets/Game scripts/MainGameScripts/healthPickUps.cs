using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUps : MonoBehaviour
{
    public ParticleSystem healthPickUpEffect;
    private ParticleSystem parInsta;
    private void Update()
    {
        transform.position += Vector3.left * SoliderEnemyScript.MovingSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            parInsta = Instantiate(healthPickUpEffect, transform.position, Quaternion.identity);
            parInsta.transform.parent = null;
            TankPlayerMovement.CurrentHealth += 20;
            Destroy(this.gameObject);
            return;
        }
    }
}
