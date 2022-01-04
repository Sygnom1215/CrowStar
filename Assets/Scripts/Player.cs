using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public float effectSoundVolume;
    public float bgmSoundVolume;
    public Item[] items;
    public bool[] clearPuzzle;

    public Player(float soundVolume)
    {
        effectSoundVolume = soundVolume;
        bgmSoundVolume = soundVolume;
        items = new Item[9];
        clearPuzzle = new bool[15];
    }
}
