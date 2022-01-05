using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private float defaultSound = 0.5f;
    [SerializeField] private Player player;

    public Player CurrentPlayer { get { return player; } }
    string SAVE_PATH = "";
    string SAVE_FILE = "/SaveFile.Json";
    private void Awake()
    {

        DataManager[] dmanagers = FindObjectsOfType<DataManager>();
        if (dmanagers.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        SAVE_PATH = Application.dataPath + "/Save";

        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();

        SoundVolumeUpdate();
    }
    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILE))
        {
            string stringJson = File.ReadAllText(SAVE_PATH + SAVE_FILE);
            player = JsonUtility.FromJson<Player>(stringJson);
        }
        else
        {
            player = new Player(defaultSound);
        }
        SaveToJson();
    }
    public void SaveToJson()
    {
        string stringJson = JsonUtility.ToJson(player, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILE, stringJson, System.Text.Encoding.UTF8);
    }
    public void DataReset()
    {
        player = new Player(defaultSound);
        SaveToJson();
        Application.Quit();
    }

    private void SoundVolumeUpdate()
    {
        SoundManager.Instance.BGMVolume(player.bgmSoundVolume);
        SoundManager.Instance.EffectVolume(player.effectSoundVolume);
    }

    public void DataClear()
    {
        player.items = new Item[9];
        player.clearPuzzle = new bool[13];
        player.watchedStory = false;
        SaveToJson();
    }

    public void SaveClears(int index)
    {
        player.clearPuzzle[index] = true;
        SaveToJson();
    }

    public bool CheckClear(int index)
    {
        return player.clearPuzzle[index];
    }

    public Item GetIventoryItem(int index)
    {
        return player.items[index];
    }

    public void SetInventoryItem(int index, Item item)
    {
        player.items[index] = item;
        SaveToJson();
    }


    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveToJson();
    }


}