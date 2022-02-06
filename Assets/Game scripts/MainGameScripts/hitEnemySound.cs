using UnityEngine;

public class hitEnemySound : MonoBehaviour
{
    public static AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
