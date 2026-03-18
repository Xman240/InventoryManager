using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform contentParent;
    public GameObject inventoryObject;
    
    private List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        if (inventoryObject != null)
        {
            inventoryObject.SetActive(false);
        }
    }

    public void ToggleInventory()
    {
        if (targetInventory == null) return;
        bool isActive = !inventoryObject.activeSelf;
        inventoryObject.SetActive(isActive);

        if (isActive)
        {
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
        
        Dictionary<InventoryItemSO, InventoryItemData> inventoryRef = targetInventory.playerInventory;
        foreach (InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            buttons.Add(tmp);
            tmp.GetComponent<InventoryButton>().InitializeButton(item);
        }
    }


    [ContextMenu("Init UI")]
    public void InitUI()
    {
       RefreshUI();
    }
}
