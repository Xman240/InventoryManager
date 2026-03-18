using UnityEngine;

public class ContainerTrigger : MonoBehaviour
{
   [SerializeField] private GameObject interactText;
   [SerializeField] private GameObject containerCanvas;
   [SerializeField] private InventoryContainer chestContainer;
   [SerializeField] private ContainerUI containerUI;

   private PlayerInteraction playerInteraction;
   private bool isOpen = false;
   private bool playerInRange = false;

   private void Start()
   {
      if (interactText != null)
         interactText.SetActive(false);

      if (containerCanvas != null)
         containerCanvas.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log("Player entered container trigger");

         playerInteraction = other.GetComponent<PlayerInteraction>();
         if (playerInteraction != null)
         {
            playerInteraction.SetCurrentContainer(this);
            playerInRange = true;

            if (interactText != null)
               interactText.SetActive(true);
         }
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log("Player exited container trigger");

         PlayerInteraction player = other.GetComponent<PlayerInteraction>();
         if (player != null)
         {
            player.ClearCurrentContainer(this);
         }

         playerInRange = false;
         isOpen = false;

         if (interactText != null)
            interactText.SetActive(false);

         if (containerCanvas != null)
            containerCanvas.SetActive(false);
      }
   }

   public void Interact()
   {
      if (!playerInRange) return;

      Debug.Log("Interacted with container");

      isOpen = !isOpen;

      if (containerCanvas != null)
         containerCanvas.SetActive(isOpen);

      if (interactText != null)
         interactText.SetActive(!isOpen);

      if (isOpen)
      {
         containerUI.debugContainer = chestContainer;
         containerUI.InitializeContainerUI(chestContainer);
      }
   }
}