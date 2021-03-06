using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : ObjectBase
{
    [SerializeField] private GameObject compass;
    [SerializeField] private Sprite paddleBoat;
    List<ItemType> itemTypes = new List<ItemType>() { ItemType.Paddle, ItemType.Compass };
    int cnt = 0;

    private void Start()
    {
        if(DataManager.Instance.CheckClear(12))
        {
            compass.SetActive(true);
            cnt++;
        }

        if(DataManager.Instance.CheckClear(10))
        {
            GetComponent<Image>().sprite = paddleBoat;
            cnt++;
        }
    }

    public override void OnMouseClick()
    {
        base.OnMouseClick();
    }

    public override void OnClick()
    {
        if(itemTypes.Contains(GameManager.Instance.GetCurItem().itemType))
        {
            if(GameManager.Instance.GetCurItem().itemType == ItemType.Compass)
            {
                compass.SetActive(true);
                DataManager.Instance.SaveClears(12);
            }
            else if(GameManager.Instance.GetCurItem().itemType == ItemType.Paddle)
            {
                GetComponent<Image>().sprite = paddleBoat;
                DataManager.Instance.SaveClears(10);
            }
            cnt++;
            base.RemoveItem();
        }
        else
        {
        }
    }

    public bool CheckIsInBoat()
    {
        return (cnt == itemTypes.Count);
    }
}
