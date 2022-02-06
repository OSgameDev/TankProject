using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class buttonCustomScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
   
}
