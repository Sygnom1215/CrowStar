using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : ObjectBase
{
    [SerializeField] Boat boat;
    [SerializeField] Lamp lamp;
    [SerializeField] GameObject zoomBoat;
    BoatMoving boatMoving;

    public override void OnMouseClick()
    {
        OnClick();
    }

    public override void OnClick()
    {
        if (boat.CheckIsInBoat() && lamp.GetIsLight())
        {
            DataManager.Instance.SaveClears(12);
            zoomBoat.SetActive(false);
            FindObjectOfType<BoatMoving>().Move();
        }
    }
}