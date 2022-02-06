using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankCanvasController : MonoBehaviour
{
    public Slider tankHealthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        tankHealthBarSlider.minValue = 0;
        tankHealthBarSlider.maxValue = TankPlayerMovement.tankHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //updating health slider
        tankHealthBarSlider.value = TankPlayerMovement.CurrentHealth;
    }
}
