using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<ArmorSlot, InventoryItemData> equipmentSlots;
    public static EquipmentManager instance;
    public event Action<Dictionary<ArmorSlot, InventoryItemData>> onEquip;

    private void Awake()
    {
        instance = this;
        InitializeEquipment();
    }
    public void InitializeEquipment()
    {
        equipmentSlots = new Dictionary<ArmorSlot, InventoryItemData>();
        equipmentSlots.Add(ArmorSlot.HELM, null);
        equipmentSlots.Add(ArmorSlot.CHEST, null);
        equipmentSlots.Add(ArmorSlot.LEGS, null);
        equipmentSlots.Add(ArmorSlot.ARMS, null);
        equipmentSlots.Add(ArmorSlot.WEAPON, null);
    }
    public void EquipItem(InventoryItemData itemToEquip)
    {
        if (itemToEquip is ArmorItemData armor)
        {
            equipmentSlots[armor.armorSlot] = itemToEquip;
            Debug.Log(equipmentSlots[armor.armorSlot].itemName + " is equipped");
        }
        else if(itemToEquip is WeaponItemData weapon)
        {
            equipmentSlots[ArmorSlot.WEAPON] = weapon;
            Debug.Log(equipmentSlots[ArmorSlot.WEAPON].itemName + " is equipped");
        }
        onEquip?.Invoke(equipmentSlots);
    }
    public void UnequipItem(ArmorSlot slot)
    {
        if (equipmentSlots.ContainsKey(slot) && equipmentSlots[slot] != null)
        {
            Debug.Log(equipmentSlots[slot].itemName + " is unequipped");
            equipmentSlots[slot] = null;
            onEquip?.Invoke(equipmentSlots);
        }
    }
}

public class EquipmentSlot
{
    public ArmorSlot armorSlot;
    public InventoryItemData equippedItem;
}
