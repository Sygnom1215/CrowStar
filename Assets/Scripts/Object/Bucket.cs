using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : ObjectBase
{
    public override void OnMouseClick()
    {
        base.OnMouseClick();
    }

    public override void OnClick()
    {
        Debug.Log("sssdf");

        if (CheckIsCorrect(itemType))
        {
            Debug.Log("sdf");
            GameManager.Instance.UIManager.RemoveItem(itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.OilBottle]);
        }
    }
}
