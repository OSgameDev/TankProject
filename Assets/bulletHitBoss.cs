
///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOSâ„˘     ////////////////////////
////////////////////////////////////////////////////////////////////

using UnityEngine;

public class bulletHitBoss : MonoBehaviour
{

    public static AudioSource aud;
    void Start()
    {
        try
        {
            aud = GetComponent<AudioSource>();
        }
        catch (System.Exception)
        {
            Debug.Log("No Audio source was found in class: bulletHitBoss . Sound getter");
        }
    }

}
