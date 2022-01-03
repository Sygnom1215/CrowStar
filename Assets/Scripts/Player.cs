using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public float effectSoundVolume;
    public float bgmSoundVolume;
    public ItemType[] items;
    public bool[] clearPuzzle;

    public Player(float soundVolume)
    {
        effectSoundVolume = soundVolume;
        bgmSoundVolume = soundVolume;
        items = new ItemType[9];
        clearPuzzle = new bool[15];
    }
}
