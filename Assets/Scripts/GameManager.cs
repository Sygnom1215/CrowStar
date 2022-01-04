using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public List<Item> items = new List<Item>();
    public List<Sprite> itemSprites = new List<Sprite>();
    public List<Item> userItems { get; private set; } = new List<Item>();
    public UIManager UIManager { get; private set; }
    public PuzzleManager PuzzleManager { get; private set; }
    public DialogueManager DialogueManager { get; private set; }

    private int activeItemIndex;

    public Item curItem { get; private set; } = null;
    [SerializeField] private int currentStage;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
        UIManager = GetComponent<UIManager>();
        PuzzleManager = GetComponent<PuzzleManager>();
        DialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Start()
    {
    }

    public int ConversionItemId(int itemId)
    {
        switch(itemId)
        {
            case 10:
                return 2;

            case 20:
                return 1;

            case 40:
                return 4;

            case 50:
                return 3;

            case 61:
                return 6;

            case 90:
                return 11;
        }

        return -1;
    }

    public void GameEnd()
    {
        DataManager.Instance.DataClear();
        SceneManager.LoadScene(ConstantManager.LOBBY_SCENE);

    }


    public void AddInventory(Item item)
    {
        userItems.Add(item);
        UIManager.AddInventory(item);
    }

    public void SetCurrentStage(int curStage)
    {
        currentStage = curStage;
        UIManager.SetActiveChapter();
    }


    #region GetSet
    public int GetCurrentStage()
    {
        return currentStage;
    }

    public void SetActiveIndex(int index)
    {
        activeItemIndex = index;
    }

    public int GetActiveIndex()
    {
        return activeItemIndex;
    }

    public void SetItem(Item item)
    {
        curItem = item;
    }

    public ItemType GetItemType()
    {
        return curItem.itemType;
    }

    public Item GetCurItem()
    {
        return curItem;
    }

    public Camera GetMainCam()
    {
        return mainCam;
    }

    #endregion
}
