using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerMove : MonoBehaviour
{
    public GameObject magnifying;
    private Vector3 mousePointer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
            Debug.Log("ÀÔ·ÂÁß");
        } 
        if(Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }

    void OnMouseDown()
    {
        mousePointer = Input.mousePosition;
        mousePointer.z = 10;
        mousePointer = Camera.main.ScreenToWorldPoint(mousePointer);
    }

    void OnMouseDrag()
    {
        Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = 10;
        worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

        Vector3 diffPos = worldPoint - mousePointer;
        diffPos.z = 0;

        mousePointer = Input.mousePosition;
        mousePointer.z = 10;
        mousePointer = Camera.main.ScreenToWorldPoint(mousePointer);

        magnifying.transform.position =
            new Vector3(Mathf.Clamp(magnifying.transform.position.x + diffPos.x, -4.5f, 4.5f) 
            , magnifying.transform.position.y + diffPos.y, magnifying.transform.position.z);
    }
}
