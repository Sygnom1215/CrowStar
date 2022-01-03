using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private bool isGetItem;
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    private void OnEnable()
    {
        col.enabled = true;
    }

    private void OnDisable()
    {
        col.enabled = false;
    }

    private void OnMouseUp()
    {
        if (transform.childCount == 0 && !isGetItem)
        {
            GameManager.Instance.AddInventory(GameManager.Instance.items.Find(x => x.itemType == ItemType.Branch));
            isGetItem = true;
        }
    }
}
