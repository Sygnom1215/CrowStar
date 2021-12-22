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

    void Start()
    {
        image= GetComponent<Image>();
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
        IsEmpty = false;
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
    private void Settings()
    {
        GameManager.Instance.SetActiveIndex(index);
        GameManager.Instance.SetItem(item);
        GameManager.Instance.UIManager.AllInventAct();
    }

    public void OnActiveEffect()
    {
        image.color = Color.white;
    }

    public void OffActiveEffect()
    {
        image.color = Color.black;
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
