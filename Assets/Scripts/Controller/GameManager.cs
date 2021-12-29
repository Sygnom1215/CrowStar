using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public List<Item> items = new List<Item>();
    public List<Item> userItems { get; private set; } 
    public UIManager UIManager { get; private set; }

    public int activeItemIndex;

    public Item curItem { get; private set; } = null;

    private void Awake()
    {
        UIManager = GetComponent<UIManager>();
        userItems = new List<Item>();
    }

    public void AddInventory(Item item)
    {
        Debug.Log(userItems);
        userItems.Add(item);
        UIManager.AddInventory(item);
    }

    public void SetActiveIndex(int index)
    {
        activeItemIndex = index;
    }

    public void SetItem(Item item)
    {
        curItem = item;
    }

    public ItemType GetItemType()
    {
        return curItem.itemType;
    }
}
