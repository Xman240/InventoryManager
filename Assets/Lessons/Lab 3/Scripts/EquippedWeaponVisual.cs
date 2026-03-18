using System.Collections.Generic;
using UnityEngine;

public class EquippedWeaponVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Sprite defaultWeaponSprite;

    private void Start()
    {
        EquipmentManager.instance.onEquip += UpdateWeaponVisual;
        UpdateWeaponVisual(EquipmentManager.instance.equipmentSlots);
    }

    private void OnDestroy()
    {
        if (EquipmentManager.instance != null)
        {
            EquipmentManager.instance.onEquip -= UpdateWeaponVisual;
        }
    }

    private void UpdateWeaponVisual(Dictionary<ArmorSlot, InventoryItemData> equipment)
    {
        if (equipment.ContainsKey(ArmorSlot.WEAPON) && equipment[ArmorSlot.WEAPON] != null)
        {
            weaponRenderer.sprite = equipment[ArmorSlot.WEAPON].icon;
        }
        else
        {
            weaponRenderer.sprite = defaultWeaponSprite;
        }
    }
}