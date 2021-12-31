using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japanki : ObjectBase
{
    public override void OnClick()
    {
        if (CheckIsCorrect(GameManager.Instance.GetCurItem().itemType))
        {
            base.RemoveItem();
            GameManager.Instance.AddInventory(GameManager.Instance.items.Find(x => x.itemType == ItemType.Paddle));
        }
    }
}
