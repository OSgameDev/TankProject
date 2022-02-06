using UnityEngine;

public class TankAnimatorGetter : MonoBehaviour
{
    public static Animator TankAnimator;
    public static AudioSource tankAud;
    void Start()
    {
        TankAnimator = GetComponent<Animator>();
        tankAud = GetComponent<AudioSource>();
    }
}
