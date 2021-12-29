using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel = null;
    private int maxInventory = 9;
    private List<InventoryPanel> inventoryPanels = new List<InventoryPanel>();
    [SerializeField] private List<Backgrounds> backgroundsList;
    [SerializeField] private List<GameObject> chapterObjects;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [SerializeField] private Button zoomOutButton;

    private RectTransform inventoryBar;

    int sceneIndex = 0;

    private void Start()
    {
        Init();

        nextButton.onClick.AddListener(() => NextBackgroundButton());
        previousButton.onClick.AddListener(() => PreviousBackgroundButton());
        zoomOutButton.onClick.AddListener(() => zoomOutButton.gameObject.SetActive(false));
        inventoryBar = inventoryPanel.transform.parent.parent.GetComponent<RectTransform>();
        SetActiveButton();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PreviousBackgroundButton();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            NextBackgroundButton();
        }
    }

    #region INVENTORY
    private void Init()
    {
        PanelMake();
    }
    private void PanelMake()
    {
        for (int i = 0; i < maxInventory; i++)
        {
            GameObject panel = Instantiate(inventoryPanel, inventoryPanel.transform.parent);
            panel.SetActive(true);

            InventoryPanel inventory = panel.GetComponent<InventoryPanel>();
            inventory.Init(i);
            inventoryPanels.Add(inventory);
        }

        inventoryPanels[0].Settings();
    }

    public void AddInventory(Item item)
    {
        for (int i = 0; i < inventoryPanels.Count; i++)
        {
            if (inventoryPanels[i].GetIsEmpty())
            {
                inventoryPanels[i].AddItem(item);
                return;
            }
        }
    }
    public void AllInventAct()
    {
        for (int i = 0; i < inventoryPanels.Count; i++)
        {
            if (inventoryPanels[i].GetIndex() == GameManager.Instance.GetActiveIndex())
            {
                inventoryPanels[i].OnActiveEffect();
            }
            else
            {
                inventoryPanels[i].OffActiveEffect();
            }
        }
        inventoryPanel.SetActive(false);
    }
    #endregion

    public void NextBackgroundButton()
    {
        int stageNum = GameManager.Instance.GetCurrentStage();
        if (sceneIndex > backgroundsList[stageNum].GetCount()) return;
        backgroundsList[stageNum].ActiveBackgrounds(++sceneIndex);
        GameManager.Instance.PuzzleManager.ActivePuzzleScene();

        SetActiveButton();
    }

    public void PreviousBackgroundButton()
    {
        int stageNum = GameManager.Instance.GetCurrentStage();
        if (sceneIndex > backgroundsList[stageNum].GetCount()) return;
        backgroundsList[stageNum].ActiveBackgrounds(--sceneIndex);
        GameManager.Instance.PuzzleManager.ActivePuzzleScene();

        SetActiveButton();
    }

    public void SetActiveButton()
    {
        int stageNum = GameManager.Instance.GetCurrentStage();

        nextButton.gameObject.SetActive(!(sceneIndex >= backgroundsList[stageNum].GetCount() - 1));
        previousButton.gameObject.SetActive(!(sceneIndex == 0));
    }

    public void SetActiveChapter()
    {
        for(int i = 0; i<chapterObjects.Count; i++)
        {
            chapterObjects[i].SetActive(i == GameManager.Instance.GetCurrentStage());
        }
    }

    public void OnUseItem()
    {
        inventoryPanels[GameManager.Instance.GetActiveIndex()].Remove();
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }

    public bool CheckIsInInventory(ItemType itemType)
    {
        for(int i = 0; i<inventoryPanels.Count;i++)
        {
            if (inventoryPanels[i].GetIsEmpty()) continue;

            if (inventoryPanels[i].GetItem().itemType == itemType) return true;
        }
        return false;
    }

    public void RemoveItem(ItemType itemType)
    {
        for (int i = 0; i < inventoryPanels.Count; i++)
        {
            if (inventoryPanels[i].GetIsEmpty()) continue;

            if (inventoryPanels[i].GetItem().itemType == itemType)
                inventoryPanels[i].Remove();
        }
    }

    public void ActiveZoomOutButton(bool isActive)
    {
        zoomOutButton.gameObject.SetActive(isActive);
    }

    public void HideOrAppearInventory()
    {
        inventoryBar.DOAnchorPosY(-inventoryBar.anchoredPosition.y, 0.5f);
    }

    public void HideStageButton()
    {
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);
    }
}
