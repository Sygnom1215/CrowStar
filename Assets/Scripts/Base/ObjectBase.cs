﻿using System.Collections;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [SerializeField] protected ItemType itemType;
    protected virtual void OnMouseUp()
    {
        if (CheckNull())
        {
            return;
        }
        OnClick();
    }
    public virtual void OnClick() { }
    protected virtual bool CheckIsCorrect(ItemType curItemType)
    {
        return (itemType == curItemType);
    }
    protected virtual bool CheckNull()
    {
        return (GameManager.Instance.curItem == null);
    }
}