using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class Backgrounds
{
    [SerializeField] private List<GameObject> backgrounds;

    public int GetCount()
    {
        return backgrounds.Count;
    }

    public void ActiveBackgrounds(int index)
    {
        for(int i = 0; i<backgrounds.Count; i++)
        {
            backgrounds[i].SetActive(i == index);
        }
    }
}
