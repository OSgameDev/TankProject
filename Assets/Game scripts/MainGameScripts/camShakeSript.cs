using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camShakeSript : MonoBehaviour
{
    #region Instance
    public static camShakeSript instance;
    void Awake() => instance = this;
    #endregion
    private Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = GetComponent<Animator>();
    }

    //Playing the animtions
    public void shakeCam()
    {
        camAnim.SetBool("shake",true);
    }
    public void intenseShake()
    {
        camAnim.SetBool("intenseShake", true);
    }

    //Stopping after done through animation event
    public void setIntenseShakeFalse()
    {
        camAnim.SetBool("intenseShake", false);
    }
    public void setShakeFalse()
    {
       camAnim.SetBool("shake", false);
    }
}
