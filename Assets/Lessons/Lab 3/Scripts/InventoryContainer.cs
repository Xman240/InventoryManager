using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public List<InventoryItemSO> startingItems = new();
    public Dictionary<InventoryItemSO, InventoryItemData> containerContents = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryManager playerInventory;
    public event Action<InventoryContainer> onContainerUpdated;

    private void Start()
    {
        foreach (InventoryItemSO item in startingItems)
        {
            if (!containerContents.TryAdd(item, item.CreateRuntimeData()))
            {
                containerContents[item].quantity += 1;
            }
        }
    }

    public void AddItemToContainer(InventoryItemSO itemToAdd_)
    {
        // remove item from player inventory
        // add item to container inventory
        playerInventory.RemoveItem(itemToAdd_);
        if (!containerContents.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData()))
        {
            containerContents[itemToAdd_].quantity += 1;
        }
        Debug.Log("Added item " + itemToAdd_.itemName + " to container.");
        onContainerUpdated?.Invoke(this);
    }

    public void AddItemToPlayerInventory(InventoryItemSO itemToAdd_)
    {
        // remove item from container inventory
        // add item to player inventory
        if (containerContents[itemToAdd_].quantity > 1)
        {
            containerContents[itemToAdd_].quantity -= 1;
        }
        else { containerContents.Remove(itemToAdd_); }

        playerInventory.AddItem(itemToAdd_);
        Debug.Log("Added item " + itemToAdd_.itemName + " to player inventory.");
        onContainerUpdated?.Invoke(this);

    }

}
