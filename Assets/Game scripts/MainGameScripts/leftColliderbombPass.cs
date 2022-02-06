using UnityEngine;

public class leftColliderbombPass : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
