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

    private void Start()
    {
        isGetItem = DataManager.Instance.CheckClear(7);
    }

    private void OnEnable()
    {
        col.enabled = true;
    }

    private void OnDisable()
    {
        col.enabled = false;
    }

    private void Update()
    {
        if (transform.childCount == 0 && !col.enabled)
        {
            col.enabled = true;
        }
    }

    private void OnMouseEnter()
    {
        if (!Input.GetMouseButton(0)) return;

        if (transform.childCount != 0)
        {
            col.enabled = false;
        }
    }

    private void OnMouseUp()
    {
        if (transform.childCount == 0 && !isGetItem)
        {
            GameManager.Instance.AddInventory(GameManager.Instance.items.Find(x => x.itemType == ItemType.Branch));
            isGetItem = true;
            DataManager.Instance.SaveClears(7); 
        }
    }
}
