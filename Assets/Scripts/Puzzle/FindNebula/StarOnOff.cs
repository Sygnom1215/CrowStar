using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarOnOff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject star = null;

    private bool starOnOff = false;

    private int click = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        starOnOff = true;

        if(starOnOff)
        {
            Color color = star.GetComponent<Image>().color;
            color.a = 1f;
            star.GetComponent<Image>().color = color;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!starOnOff && click <= 0)
        {
            Color color = star.GetComponent<Image>().color;
            color.a = 0f;
            star.GetComponent<Image>().color = color;
        }
    }

    public void Click()
    {
        click++;

        if(click >= 1)
        {
            starOnOff = true;

            if (starOnOff)
            {
                Color color = star.GetComponent<Image>().color;
                color.a = 1f;
                star.GetComponent<Image>().color = color;
            }
        }
    }
}
