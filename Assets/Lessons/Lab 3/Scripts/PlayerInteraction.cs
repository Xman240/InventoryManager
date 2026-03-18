using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InventoryUIManager inventoryUIManager;

    private InputSystem_Actions player;
    private ContainerTrigger currentContainer;

    private void Awake()
    {
        player = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        player.Player.Enable();

        player.Player.Interact.performed += OnInteract;
        player.Player.Inventory.performed += OnInventory;
    }

    private void OnDisable()
    {
        player.Player.Interact.performed -= OnInteract;
        player.Player.Inventory.performed -= OnInventory;

        player.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {

        if (currentContainer != null)
        {
            currentContainer.Interact();
        }
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
       
        inventoryUIManager.ToggleInventory();
    }

    public void SetCurrentContainer(ContainerTrigger container)
    {
        currentContainer = container;
    }

    public void ClearCurrentContainer(ContainerTrigger container)
    {
        if (currentContainer == container)
        {
            currentContainer = null;
        }
    }
}