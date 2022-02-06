using UnityEngine;

public class bulletHitTankSound : MonoBehaviour
{
    public static AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
