using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneEnemy : MonoBehaviour
{
    [Header("PLANE VARIABLES")]
    [Space]
    public int airPlaneHealth;
    public float droppingBombDelay;
    public float planeMovingSpeed;
    public static bool airplaneIsReady = false;
    IEnumerator bombingDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(droppingBombDelay);
            airplaneIsReady = true;
        }
    }
    public void planeTakeDamage(int damage)
    {
        airPlaneHealth -= damage;
        if (airPlaneHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(bombingDelay());
        //moving 
        transform.position += Vector3.left * planeMovingSpeed * Time.deltaTime;
    }
}
