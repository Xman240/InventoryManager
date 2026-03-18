using UnityEngine;
[CreateAssetMenu(fileName = "ArmorItemSO", menuName = "Inventory System/ArmorItemSO")]

public class ArmorItemSO: InventoryItemSO
{
    public int armorRating;
    public int armorDurability;
    public ArmorSlot armorSlot;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmorItemData(this);
    }
}

public enum ArmorSlot
{
    HELM,
    CHEST,
    LEGS,
    ARMS,
    WEAPON
}
