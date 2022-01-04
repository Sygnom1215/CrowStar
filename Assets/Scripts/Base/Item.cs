using UnityEngine;
[System.Serializable]
public class Item
{
    public string name;
    public ItemType itemType;

    public Item()
    {
        name = "";
        itemType = ItemType.None;
    }
}
