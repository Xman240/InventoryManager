using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "Inventory System/InventoryItemSO")]
public abstract class InventoryItemSO : ScriptableObject
{
    public string itemName;
    public string flavourText;
    public Sprite icon;

    public abstract InventoryItemData CreateRuntimeData();
}
