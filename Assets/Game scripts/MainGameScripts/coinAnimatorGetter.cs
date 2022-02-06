using UnityEngine;

public class coinAnimatorGetter : MonoBehaviour
{
    public static Animator coinAnimator;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        coinAnimator = anim;
    }
    
}
