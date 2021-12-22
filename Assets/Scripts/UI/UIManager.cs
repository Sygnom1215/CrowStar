using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel = null;
    private int maxInventory = 9;
    private List<InventoryPanel> inventoryPanels = new List<InventoryPanel>();
    private void Start()
    {
        Init();
    }
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

        Debug.Log("인벤토리가 다 찼습니다.");
    }
    public void AllInventAct()
    {
        for (int i = 0; i < inventoryPanels.Count; i++)
        {
            if (inventoryPanels[i].GetIndex() == GameManager.Instance.activeItemIndex)
            {
                inventoryPanels[i].OnActiveEffect();
            }
            else
            {
                inventoryPanels[i].OffActiveEffect();
            }
        }
    }
}
