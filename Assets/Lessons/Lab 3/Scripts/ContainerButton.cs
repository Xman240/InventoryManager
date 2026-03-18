using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerButton : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text flavourText;
    public TMP_Text quantityDisplay;
    public Image icon;
    private InventoryItemData inventoryData;
    private InventoryContainer container;
    private bool isContainerButton;

    public void InitializeButton(InventoryItemData item, InventoryContainer container_, bool isContainerButton_)
    {
        inventoryData = item;
        isContainerButton = isContainerButton_;
        container = container_;
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
        if (isContainerButton)
        {
            container.AddItemToPlayerInventory(inventoryData.config);
            return;
        }
        container.AddItemToContainer(inventoryData.config);
    }
}
