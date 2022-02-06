using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightColliderController : MonoBehaviour
{
    public static BoxCollider2D collider;
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
    private void Update()
    {
        collider.enabled = true;
    }
}
