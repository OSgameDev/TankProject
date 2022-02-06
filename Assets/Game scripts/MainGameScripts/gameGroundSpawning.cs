using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameGroundSpawning : MonoBehaviour
{
    public GameObject GameGroundPrefab;
    [Range(1, 10)]
    public float MovingSpeed;
    public float maxTime;
    private float Timer;
    // Update is called once per frame
    void Update()
    {
        if (Timer > maxTime)
        {
            GameObject GameGround = Instantiate(GameGroundPrefab, transform.position, Quaternion.identity);
            GameGround.transform.position = new Vector3(7.0894f, -5.64f, 0);
            GameGround.transform.rotation = Quaternion.Euler(180, 0, 0);
            Destroy(GameGround, 9);
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }
}
