using UnityEngine;
public class sprayFireSound : MonoBehaviour
{
    public static AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
}
