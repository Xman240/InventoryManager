using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{


    public List<EquipmentUISlot> equipmentUISlots = new List<EquipmentUISlot>();
    private Dictionary<ArmorSlot, Image> equipmentUIDictionary = new();
    private Dictionary<ArmorSlot, Sprite> equipmentDefaultSprites = new();
    private void Start()
    {
        EquipmentManager.instance.onEquip += UpdateUI;

        foreach(var equipment in equipmentUISlots)
        {
            equipmentUIDictionary.Add(equipment.armorSlot, equipment.uiImage);
            equipmentDefaultSprites.Add(equipment.armorSlot, equipment.defaultIcon);
        }
        UpdateUI(EquipmentManager.instance.equipmentSlots);
    }
    public void UpdateUI(Dictionary<ArmorSlot, InventoryItemData> equipment)
    {
      foreach(ArmorSlot a in equipment.Keys)
        {
            Image slotImage = equipmentUIDictionary[a];
            
            if (equipment[a] != null)
            {
                slotImage.sprite = equipment[a].icon;
                Color tmp = slotImage.color;
                tmp.a = 1;
                slotImage.color = tmp;
            }
            else
            {
                equipmentUIDictionary[a].sprite = equipmentDefaultSprites[a];
                Color tmp = slotImage.color;
                tmp.a = 1;
                slotImage.color = tmp;
            }
        }

        
    }
}

[Serializable]
public class EquipmentUISlot
{
    public ArmorSlot armorSlot;
    public Image uiImage;
    public Sprite defaultIcon;
}
