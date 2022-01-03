using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    private Item item;
    [SerializeField] public ObjectData itemData;

    private void Start()
    {
        if (itemData.itemType != ItemType.Count)
            item = GameManager.Instance.items[(int)itemData.itemType];
    }

    public void OnPut()
    {
        if (itemData.itemType == ItemType.Count) return;

        if (itemData.itemType == ItemType.BrokenKey && GameManager.Instance.UIManager.CheckIsInInventory(itemData.itemType))
        {
            GameManager.Instance.UIManager.RemoveItem(itemData.itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.Key]);
        }

        else
        {
            GameManager.Instance.AddInventory(item);
            if (itemData.id == 0)
                DestroyObject();
        }
    }

    public void SaveClears(int id)
    {
        DataManager.Instance.SaveClears(id);
    }

    public void DestroyObject()
    {
        if (itemData.itemType == ItemType.Count) return;

        Destroy(gameObject);
    }
}
