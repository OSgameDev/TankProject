using UnityEngine;

public class bombExplosionSound : MonoBehaviour
{
    public static AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
