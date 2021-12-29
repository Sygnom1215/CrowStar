using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoSingleton<GameManager>
{
    public List<Item> items = new List<Item>();
    public List<Item> userItems { get; private set; } = new List<Item>();
    public UIManager UIManager { get; private set; }
    public PuzzleManager PuzzleManager { get; private set; }

    private int activeItemIndex;

    public Item curItem { get; private set; } = null;
    [SerializeField] private int currentStage;

    private Camera mainCam;
    private float cameraSize;

    private void Awake()
    {
        mainCam = Camera.main;
        cameraSize = mainCam.orthographicSize;
        UIManager = GetComponent<UIManager>();
        PuzzleManager = GetComponent<PuzzleManager>();
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

    public Camera GetMainCam()
    {
        return mainCam;
    }

    #endregion
}
