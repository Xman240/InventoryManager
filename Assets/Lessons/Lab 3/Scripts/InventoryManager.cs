using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> playerInventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryItemSO[] tmp;
    private void Awake()
    {
        foreach (InventoryItemSO item in tmp)
        {
            AddItem(item);
        }
    }

    public void AddItem(InventoryItemSO itemToAdd_)
    {
        if(!playerInventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData()))
        {
            playerInventory[itemToAdd_].quantity += 1;
        }
    }

    public void RemoveItem(InventoryItemSO itemToRemove_)
    {
        if (playerInventory[itemToRemove_].quantity > 1)
        {
            playerInventory[itemToRemove_].quantity -= 1;
            return;
        }
        playerInventory.Remove(itemToRemove_);
    }
}

[Serializable]

public abstract class InventoryItemData
{
    public InventoryItemSO config;
    public int quantity;
    public string itemName;
    public string flavourText;
    public Sprite icon;
}

[Serializable]
public class WeaponItemData: InventoryItemData
{
    public int weaponStrength;
    public int weaponDurability;
    public WeaponType weaponType;

    public WeaponItemData(WeaponItemSO config)
    {
        this.config = config;
        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.icon = config.icon;
        this.weaponDurability = config.weaponDurability;
        this.weaponStrength = config.weaponStrength;
        quantity = 1;
    }
}
[Serializable]

public class ArmorItemData:InventoryItemData
{
    public int armorRating;
    public int armorDurability;
    public ArmorSlot armorSlot;
    public ArmorItemData(ArmorItemSO config)
    {
        this.config = config;
        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.armorRating = config.armorRating;
        this.armorDurability = config.armorDurability;
        this.armorSlot = config.armorSlot;
        this.icon = config.icon;
        quantity = 1;
    }
}


