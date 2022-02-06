
///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOS™     ////////////////////////
////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpingCloudController : MonoBehaviour
{
    public float movingSpeed;
    public static bool isCloudSpawned;


    private void Awake() => isCloudSpawned = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * movingSpeed * Time.deltaTime;
    }
    private void OnDestroy()
    {
        isCloudSpawned = false;
    }

}
