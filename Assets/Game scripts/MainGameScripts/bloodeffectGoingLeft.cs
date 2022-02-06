using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodeffectGoingLeft : MonoBehaviour
{
    public float movingLeftSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movingLeftSpeed * Time.deltaTime;
    }
}
