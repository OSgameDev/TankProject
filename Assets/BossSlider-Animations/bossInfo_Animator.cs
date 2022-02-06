///////////////////////////////////////////////////////////////////////
////////////////////////  CODE MADE BY OMAR   ////////////////////////
///////////////////////     OMARSTUDIOS™     ////////////////////////
////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
public class bossInfo_Animator : MonoBehaviour
{
    public static Animator anim;
    public static CanvasGroup canvasG;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        canvasG = GetComponent<CanvasGroup>();
    }

    public void returnToIdle()
    {
        anim.SetBool("done", true);
    }
}
