using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public static Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
}
