using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickLamplight : MonoBehaviour, IDragHandler
{
    public RectTransform lamp;

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            LampLightFollow();
        }
    }

    void LampLightFollow()
    {
        Vector2 worldPointion = Input.mousePosition;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(worldPointion);

        lamp.position = mousePos;

        lamp.position = lamp.position;
    }
}
