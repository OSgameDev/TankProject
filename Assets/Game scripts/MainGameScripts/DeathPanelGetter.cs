using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanelGetter : MonoBehaviour
{
    public static GameObject DeathPanel;
    // Update is called once per frame
    void Awake()
    {
        DeathPanel = this.gameObject;
    }
}
