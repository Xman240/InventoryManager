using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform inventoryContentParent;
    public Transform containerContentParent;
    private List<GameObject> inventoryButtons = new();
    private List<GameObject> containerButtons = new();
    [Header("Debug")]
    public InventoryContainer debugContainer;
    
    private InventoryContainer currentContainer;

    private void Start()
    {
        if(debugContainer != null) InitializeContainerUI(debugContainer);
    }


    public void InitializeContainerUI(InventoryContainer container_)
    {
       if(currentContainer != null)
       {
           currentContainer.onContainerUpdated -=  UpdateContainerUI;
       }
       
       currentContainer = container_;
       
       currentContainer.onContainerUpdated -= UpdateContainerUI;
       currentContainer.onContainerUpdated += UpdateContainerUI;
       
        UpdateContainerUI(currentContainer);
    }

    public void UpdateContainerUI(InventoryContainer container_)
    {
        
        foreach(GameObject obj in inventoryButtons)
        {
            Destroy(obj);
        }
        inventoryButtons.Clear();

        foreach (GameObject obj in containerButtons)
        {
            Destroy(obj);
        }
        containerButtons.Clear();

         Dictionary<InventoryItemSO, InventoryItemData> playerInventoryRef = targetInventory.playerInventory;
        Dictionary<InventoryItemSO, InventoryItemData> containerInventoryRef = container_.containerContents;
        foreach (InventoryItemData item in playerInventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, inventoryContentParent);
            inventoryButtons.Add(tmp);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, false);
        }

        foreach (InventoryItemData item in containerInventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, containerContentParent);
            containerButtons.Add(tmp);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, true);
        }
    }
}
