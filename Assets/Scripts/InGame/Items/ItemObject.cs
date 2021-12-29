using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    Item item;
    [SerializeField] private ItemType itemType;

    private void Start()
    {
        item = GameManager.Instance.items[(int)itemType];
    }

    private void OnMouseUp()
    {
        GameManager.Instance.AddInventory(item);
        Destroy(gameObject);
    }
}
