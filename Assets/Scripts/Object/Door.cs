using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : ObjectBase,IPointerUpHandler
{
    public override void OnClick()
    {
        if(CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            GameManager.Instance.SetCurrentStage(GameManager.Instance.GetCurrentStage() + 1);
            RemoveItem();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnMouseClick();
    }
}
