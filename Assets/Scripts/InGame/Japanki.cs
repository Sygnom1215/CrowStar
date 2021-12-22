using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japanki : MonoBehaviour
{
    private bool CheckItems()
    {
        for (int i = 0; i < GameManager.Instance.userItems.Count; i++)
        {
            if (GameManager.Instance.userItems[i].itemType == ItemType.Hammer)
            {
                GameManager.Instance.userItems[i] = GameManager.Instance.items[1];
            }
        
        }
        return false;
    }
}
