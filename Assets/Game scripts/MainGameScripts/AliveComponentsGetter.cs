using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveComponentsGetter : MonoBehaviour
{
    public static GameObject controllsPanel;
    void Awake()
    {
        controllsPanel = this.gameObject;
    }

}
