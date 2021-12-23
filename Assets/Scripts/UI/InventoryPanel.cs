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
    
    void Awake()
    {
        image = GetComponent<Image>();
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
        itemImage.sprite = item.sprite;
        itemImage.color = Color.white;

        IsEmpty = false;
    }

    public void Remove()
    {
        item = null;
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
        image.color = Color.white;
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
