using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Item item;
    [SerializeField] public ObjectData itemData;
    private Button button;

    private void Start()
    {
        item = GameManager.Instance.items[(int)itemData.itemType];
        button = GetComponent<Button>();

        button.onClick.AddListener(() => OnPut());
    }

    private void OnPut()
    {
        if(GameManager.Instance.UIManager.CheckIsInInventory(itemData.itemType))
        {
            GameManager.Instance.UIManager.RemoveItem(itemData.itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.Key]);
        }
        else
        {
            GameManager.Instance.AddInventory(item);
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
