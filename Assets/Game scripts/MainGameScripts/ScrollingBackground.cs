using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollingSpeed = 0.09f;
    Renderer ScrollingObjectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ScrollingObjectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!TankPlayerMovement.isTankAlive) return;
        Vector2 offset = new Vector2(Time.time * scrollingSpeed, 0);
        ScrollingObjectRenderer.material.mainTextureOffset = offset;
    }
}
