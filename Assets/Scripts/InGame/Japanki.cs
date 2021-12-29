using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japanki : ObjectBase
{
    private int changeItemIndex = 1;

    public override void OnClick()
    {

        if (CheckIsCorrect(GameManager.Instance.curItem.itemType))
        {
            GameManager.Instance.AddInventory(GameManager.Instance.items[changeItemIndex]); 
            Debug.Log("O");
        }
        else
        {
            Debug.Log("X");
            return;
        }
        return;
    }

}
