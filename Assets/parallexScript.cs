
///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOS™     ////////////////////////
////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallexScript : MonoBehaviour
{
    public float parallexEffect;
    public GameObject mainCamera;

    private float startPos;
    private float length;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        distance = mainCamera.transform.position.x * parallexEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }

}
