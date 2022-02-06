using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveHandler : MonoBehaviour
{
    public Material material;
    public float timeBeforeDissolving;
    private float dissolveAmount = 1;

    // Update is called once per frame
    IEnumerator dissolveDelay()
    {
        yield return new WaitForSeconds(timeBeforeDissolving);
        dissolveAmount -= Time.deltaTime / 2.5f;
        Mathf.Clamp(dissolveAmount, 1, -0.12f);
        material.SetFloat("dissolveAmount", dissolveAmount);
    }
    void Update()
    {
        if (firstBossScript.isDead)
        {
            StartCoroutine(dissolveDelay());
        }
        Mathf.Clamp(dissolveAmount, 1, -0.12f);
        
    }
}
