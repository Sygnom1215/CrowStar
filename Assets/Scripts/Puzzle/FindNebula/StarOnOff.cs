using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarOnOff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] private GameObject star = null;
    [SerializeField] private MousePointerMove pointer = null;
    Image image;
    private bool starOnOff = false;
    private ItemObject itemObject;
    private int click = 0;

    public bool isFind { get; private set; }

    private void Start()
    {
        image = GetComponent<Image>();
        itemObject = GetComponent<ItemObject>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        starOnOff = true;
        if (!pointer.isDrag) return;

        if(starOnOff)
        {
            Color color = image.color;
            color.a = 1f;
            isFind = true;
            image.color = color;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!starOnOff && click <= 0)
        {
            Color color = image.color;
            color.a = 0f;
            image.color = color;
        }
    }

    public void Click()
    {
        if (!isFind) return;

        click++;

        if(click >= 1)
        {
            starOnOff = true;

            if (starOnOff)
            {
                Color color = image.color;
                color.a = 1f;
                image.color = color;
            }
        }

        GameManager.Instance.DialogueManager.Action(gameObject);
        itemObject.OnPut();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Click();
    }
}
