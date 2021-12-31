using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : ObjectBase
{
    List<ItemType> itemTypes = new List<ItemType>() { ItemType.Paddle, ItemType.Compass };
    int cnt = 0;

    public override void OnMouseClick()
    {
        base.OnMouseClick();
    }

    public override void OnClick()
    {
        if(itemTypes.Contains(GameManager.Instance.GetCurItem().itemType))
        {
            cnt++;
            base.RemoveItem();
        }
        else
        {
        }
    }

    public bool CheckIsInBoat()
    {
        return (cnt == itemTypes.Count);
    }
}
