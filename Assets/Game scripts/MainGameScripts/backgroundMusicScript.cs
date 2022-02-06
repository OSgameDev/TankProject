using UnityEngine;

public class backgroundMusicScript : MonoBehaviour
{
    public static AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
