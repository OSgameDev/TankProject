using UnityEngine;

public class coinColletSound : MonoBehaviour
{
    public static AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
