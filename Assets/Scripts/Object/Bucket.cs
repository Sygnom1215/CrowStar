using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : ObjectBase
{
    private bool isServe;
    public override void OnMouseClick()
    {
        OnClick();
    }

    public override void OnClick()
    {
        if(GameManager.Instance.GetCurItem() == null)
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
            return;
        }

        if (!CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }

        else if (CheckIsCorrect(GameManager.Instance.GetItemType()) && !isServe)
        {
            SoundManager.Instance.SetEffectSound(13);
            isServe = true;
            GameManager.Instance.UIManager.RemoveItem(itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.OilBottle]);
        }
    }
}
