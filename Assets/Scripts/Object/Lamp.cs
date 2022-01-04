using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : ObjectBase
{
    private bool isFirstIn;
    private bool isLight;
    private List<ItemType> itemTypes = new List<ItemType>() { ItemType.OilBottle, ItemType.Matches };
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject lightGlow;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        isFirstIn = DataManager.Instance.CheckClear(8);
        isLight = DataManager.Instance.CheckClear(9);

        if(isFirstIn && !isLight)
        {
            image.sprite = sprites[0];
        }

        else if(isFirstIn && isLight)
        {
            image.sprite = sprites[1];
            lightGlow.SetActive(true);
        }
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
                DataManager.Instance.SaveClears(8);
                OnUseItem(0);
            }

            else if (isFirstIn && item.itemType == ItemType.Matches)
            {
                OnUseItem(1);
                DataManager.Instance.SaveClears(9);
                lightGlow.SetActive(true);
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
