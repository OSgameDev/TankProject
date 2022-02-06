using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinColletScript : MonoBehaviour
{
    private float movingLeftSpeed;
    CircleCollider2D col;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        //anim = GetComponent<Animator>();
        //anim.SetBool("isCollected", false);
    }
    private void Update()
    {
        movingLeftSpeed = SoliderEnemyScript.MovingSpeed;
        this.transform.position += Vector3.left * movingLeftSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            col.isTrigger = false;
        }
        if (collision.gameObject.layer == 8)
        {
            col.isTrigger = true;
            playerCoinManagment.inGamePlayerMoney += 5;
            coinColletSound.aud.Play();
            //anim.SetBool("isCollected", true);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            col.isTrigger = true;
            Destroy(this.gameObject, 1);
        }
    }
}
