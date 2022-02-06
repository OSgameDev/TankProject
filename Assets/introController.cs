
///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOS™     ////////////////////////
////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class introController : MonoBehaviour
{
    public float introDuration;
    public void switchToGameScene()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator waitForSceneLoad()
    {
        yield return new WaitForSeconds(introDuration);
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitForSceneLoad());
        
    }

}
