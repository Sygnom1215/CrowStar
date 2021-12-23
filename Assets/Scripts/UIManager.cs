using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel = null;
    private int maxInventory = 9;
    private List<InventoryPanel> inventoryPanels = new List<InventoryPanel>();
    [SerializeField] private List<Backgrounds> backgroundsList;
    [SerializeField] private List<GameObject> chapterObjects;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    int index = 0;

    private void Start()
    {
        Init();

        nextButton.onClick.AddListener(() => NextBackgroundButton());
        previousButton.onClick.AddListener(() => PreviousBackgroundButton());

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
        if (index > backgroundsList[stageNum].GetCount()) return;
        backgroundsList[stageNum].ActiveBackgrounds(++index);

        SetActiveButton();
    }

    public void PreviousBackgroundButton()
    {
        int stageNum = GameManager.Instance.GetCurrentStage();
        if (index > backgroundsList[stageNum].GetCount()) return;
        backgroundsList[stageNum].ActiveBackgrounds(--index);

        SetActiveButton();
    }

    private void SetActiveButton()
    {
        int stageNum = GameManager.Instance.GetCurrentStage();

        nextButton.gameObject.SetActive(!(index >= backgroundsList[stageNum].GetCount() - 1));
        previousButton.gameObject.SetActive(!(index == 0));
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
}
