using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text flavourText;
    public TMP_Text quantityDisplay;
    public Image icon;
    private InventoryItemData inventoryData;

    public void InitializeButton(InventoryItemData item)
    {
        inventoryData = item;
        itemName.text = item.itemName;
        flavourText.text = item.flavourText;
        quantityDisplay.text = item.quantity.ToString();
        icon.sprite = item.icon;
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ButtonClick);
    }

    public void ButtonClick()
    {
        EquipmentManager.instance.EquipItem(inventoryData);

        //InventoryContainer container;
        //container.AddItemToPlayerInventory(inventoryData.config);
        //container.AddItemToContainer(inventoryData.config);
    }
}
