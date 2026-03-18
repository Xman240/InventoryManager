using UnityEngine;
using UnityEngine.UI;

public class SimpleEnemyScript : MonoBehaviour,IDamageable
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Image healthBarFill;

    [Header("Death Reward")]
    [SerializeField] private InventoryItemSO itemToDrop;
    [SerializeField] private int amountToGive = 1;
    [SerializeField] private InventoryManager playerInventory;

    private float currentHealth;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        if (playerInventory != null && itemToDrop != null)
        {
            for (int i = 0; i < amountToGive; i++)
            {
                playerInventory.AddItem(itemToDrop);
            }
        }
        if (PickupMessage.instance != null)
        {
            PickupMessage.instance.ShowMessage(
                "Added " + itemToDrop.itemName + " to Inventory"
            );
        }

        Destroy(gameObject);
    }
}
