using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotButton : MonoBehaviour
{
    [SerializeField] private ArmorSlot slot;
    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        EquipmentManager.instance.UnequipItem(slot);
    }
}
