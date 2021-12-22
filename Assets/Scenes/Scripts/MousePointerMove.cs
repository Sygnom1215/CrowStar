using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePointerMove : MonoBehaviour
{
    public RectTransform glass;

    private void Start()
    {
        Init_Cursor();
    }

    private void Update()
    {
        Update_MousePosition();
    }
    private void Init_Cursor()
    {
        Cursor.visible = false;

        if (glass.GetComponent<Graphic>())
            glass.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 worldPointion = Input.mousePosition;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(worldPointion);

        glass.position = mousePos;

        glass.position = glass.position;
    }
}
