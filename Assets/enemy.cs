using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int despawnThreshold = 3;
    public float moveSpeed = 5.0f;
    public float detectionRange = 10.0f; // Adjust the detection range as needed

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        // Check if the player is within the detection range
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        // Optional: Implement despawn logic here based on certain conditions
        if (currentHealth <= 0)
        {
            Despawn();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        // Subtract damage from the enemy's health
        currentHealth -= damageAmount;

        // Perform any additional actions (e.g., play damage animation, check for despawn)
        if (currentHealth <= 0)
        {
            Despawn();
        }
    }

    void Despawn()
    {
        // Handle enemy despawn (e.g., play death animation, disable GameObject)
        Debug.Log("Enemy has despawned!");
        Destroy(gameObject);
        // Implement any other logic for enemy despawn here
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        Debug.Log("Enemy Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Adjust the damage amount as needed
                Debug.Log("Player has taken damage!");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the enemy is hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            // Deal damage to the enemy
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                Debug.Log("Enemy has taken damage!");
                TakeDamage(bullet.damageAmount);
            }

            // Destroy the bullet
            Destroy(other.gameObject);
        }
    }
}