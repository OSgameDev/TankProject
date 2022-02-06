using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundToLeft : MonoBehaviour
{
    public float movingSpeed;
    void Update()
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }
}
