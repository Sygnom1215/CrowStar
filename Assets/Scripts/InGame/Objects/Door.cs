using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ObjectBase
{
    
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
    }

    public override void OnClick()
    {
        if (CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("����");
        }
    }
}
