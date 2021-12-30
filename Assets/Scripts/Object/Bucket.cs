using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : ObjectBase
{
    private bool isServe;
    public override void OnMouseClick()
    {
        base.OnMouseClick();
    }

    public override void OnClick()
    {
        if (CheckIsCorrect(GameManager.Instance.GetItemType()) && !isServe)
        {
            isServe = true;
            GameManager.Instance.UIManager.RemoveItem(itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.OilBottle]);
        }
        else if (!CheckIsCorrect(GameManager.Instance.GetItemType()) || GameManager.Instance.GetCurItem()==null)
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }
    }
}
