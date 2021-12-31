using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : ObjectBase
{
    [SerializeField] Boat boat;
    [SerializeField] Lamp lamp;

    public override void OnMouseClick()
    {
        OnClick();
    }

    public override void OnClick()
    {
        if (boat.CheckIsInBoat() && lamp.GetIsLight())
        {
            Debug.Log("³¡!!");
        }
    }
}