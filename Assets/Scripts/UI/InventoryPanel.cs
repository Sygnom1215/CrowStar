using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour, IPointerUpHandler
{
    private int index = 0;
    private bool IsEmpty = true;
    private Item item = null;
    private Image image = null;
    [SerializeField] private Image itemImage = null;
    private Color32 originColor;
    private Color32 selectedColor = new Color32(174,174,174,214);
    
    void Awake()
    {
        image = GetComponent<Image>();
        originColor = image.color;
        itemImage.color = Color.clear;
    }

    public void Init(int index)
    {
        this.index = index;
    }

    public void AddItem(Item item)
    {
        if (this.item != null) return;

        this.item = item;
        Settings();
        itemImage.sprite = GameManager.Instance.itemSprites[(int)item.itemType];
        itemImage.color = Color.white;
        DataManager.Instance.SetInventoryItem(index, item);

        IsEmpty = false;
    }

    public void Remove()
    {
        item = null;
        DataManager.Instance.SetInventoryItem(index, null);
        itemImage.color = Color.clear;
        IsEmpty = true;
    }

    public void UseItem()
    {
        item = null;
        IsEmpty = true;
    }

    public bool GetIsEmpty()
    {
        return IsEmpty;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Settings();
    }
    public void Settings()
    {
        GameManager.Instance.SetActiveIndex(index);
        GameManager.Instance.SetItem(item);
        GameManager.Instance.UIManager.AllInventAct();
    }

    public void OnActiveEffect()
    {
        image.color = Color.yellow;
    }

    public void OffActiveEffect()
    {
        image.color = originColor;
    }

    public int GetIndex()
    {
        return index;
    }

    public Item GetItem()
    {
        return item;
    }
}
