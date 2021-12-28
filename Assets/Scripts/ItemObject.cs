using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    Item item;
    [SerializeField] private ItemType itemType;
    private Button button;

    private void Start()
    {
        item = GameManager.Instance.items[(int)itemType];
        button = GetComponent<Button>();

        button.onClick.AddListener(() => OnPut());
    }

    private void OnPut()
    {
        if(GameManager.Instance.UIManager.CheckIsInInventory(itemType))
        {
            GameManager.Instance.UIManager.RemoveItem(itemType);
            GameManager.Instance.UIManager.AddInventory(GameManager.Instance.items[(int)ItemType.Key]);
        }
        else
        {
            GameManager.Instance.AddInventory(item);
        }
        Destroy(gameObject);
    }
}
