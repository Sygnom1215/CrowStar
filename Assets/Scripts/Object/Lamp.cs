using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : ObjectBase
{
    private bool isFirstIn;
    private bool isLight;
    private List<ItemType> itemTypes = new List<ItemType>() { ItemType.OilBottle, ItemType.Matches };
    [SerializeField] Sprite[] sprites;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public override void OnMouseClick()
    {
        base.OnMouseClick();
    }

    public override void OnClick()
    {
        Item item = GameManager.Instance.GetCurItem();

        if (itemTypes.Contains(item.itemType))
        {
            if (!isFirstIn && item.itemType == ItemType.OilBottle)
            {
                isFirstIn = true;
                OnUseItem(0);
            }

            else if (isFirstIn && item.itemType == ItemType.Matches)
            {
                OnUseItem(1);
                isLight = true;
            }

            else
                GameManager.Instance.DialogueManager.Action(gameObject);
        }
        else
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }
    }

    private void OnUseItem(int index)
    {
        image.sprite = sprites[index];
        base.RemoveItem();
    }

    public bool GetIsLight()
    {
        return isLight;
    }
}
