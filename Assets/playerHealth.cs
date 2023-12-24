using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player has taken " + damageAmount + " damage!");
        // Subtract damage from the player's health
        currentHealth -= damageAmount;

        // Perform any additional actions (e.g., play damage animation, check for death)
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., reset position, restart level)
        Destroy(gameObject);
        Debug.Log("Player has died!");
        // Implement your logic for player death here
    }
}