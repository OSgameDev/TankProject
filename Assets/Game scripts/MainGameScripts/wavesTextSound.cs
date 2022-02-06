using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavesTextSound : MonoBehaviour
{
    public static AudioSource aud;
    void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
}
