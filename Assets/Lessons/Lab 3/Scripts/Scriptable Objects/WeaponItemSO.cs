using UnityEngine;
[CreateAssetMenu(fileName = "WeaponItemSO", menuName = "Inventory System/WeaponItemSO")]

public class WeaponItemSO:InventoryItemSO
{
    public int weaponStrength;
    public int weaponDurability;
    public WeaponType weaponType;

    public override InventoryItemData CreateRuntimeData()
    {
        return new WeaponItemData(this);
    }
}

public enum WeaponType
{
    SWORD,
    AXE,
    STAFF
}
