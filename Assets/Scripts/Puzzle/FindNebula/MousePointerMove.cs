using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePointerMove : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    public RectTransform glass;
    public bool isDrag;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        glass.position = new Vector3(Mathf.Clamp(mousePos.x, ConstantManager.MIN_POSITION.x, ConstantManager.MAX_POSITION.x),
            Mathf.Clamp(mousePos.y, ConstantManager.MIN_POSITION.y, ConstantManager.MAX_POSITION.y), 0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cursor.visible = true;
        isDrag = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Cursor.visible = false;
        isDrag = true;
    }
}
