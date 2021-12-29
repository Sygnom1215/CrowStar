using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : ObjectBase, IPointerUpHandler
{
    public override void OnClick()
    {
        if (GameManager.Instance.GetCurItem() == null || !CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }

        else
        {
            GameManager.Instance.SetCurrentStage(GameManager.Instance.GetCurrentStage() + 1);
            RemoveItem();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClick();
    }
}
