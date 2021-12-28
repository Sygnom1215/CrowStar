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

    public void ZoomInCamera(Vector2 pos)
    {
        float zoomDuration = 1f;
        mainCam.DOOrthoSize(3f, zoomDuration);
        mainCam.transform.DOMove(FitCamera(pos, 3f), zoomDuration);

        UIManager.AcriveZoomOutButton(true);
    }

    public void ZoomOutCamera()
    {
        mainCam.transform.DOMove(Vector2.zero, 1f);
        mainCam.DOOrthoSize(cameraSize, 1f);
        UIManager.AcriveZoomOutButton(false);
    }

    private Vector2 FitCamera(Vector2 pos, float zoom)
    {
        float matchX = Mathf.Abs((cameraSize - zoom) / cameraSize * ConstantManager.MIN_POSITION.x);
        float matchY = Mathf.Abs((cameraSize - zoom) / cameraSize * ConstantManager.MIN_POSITION.y);

        if (Mathf.Abs(pos.x) > matchX)
        {
            if (pos.x > 0) pos = new Vector2(matchX, pos.y);
            else pos = new Vector2(-matchX, pos.y);
        }

        if (Mathf.Abs(pos.y) > matchY)
        {
            if (pos.y > 0) pos = new Vector2(pos.x, matchY);
            else
                pos = new Vector2(pos.x, -matchY);
        }

        return pos;
    }

    #endregion
}
