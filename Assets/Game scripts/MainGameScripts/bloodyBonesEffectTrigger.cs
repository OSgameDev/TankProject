using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodyBonesEffectTrigger : MonoBehaviour
{
    public ParticleSystem bloodyBones;
    // Start is called before the first frame update
    void Awake()
    {
        bloodyBones.Play();
    }
    private void Update()
    {
        transform.position += Vector3.left * SoliderEnemyScript.MovingSpeed * Time.deltaTime;
    }


}
