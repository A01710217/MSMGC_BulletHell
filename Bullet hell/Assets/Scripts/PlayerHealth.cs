using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jugador
    private float currentHealth; // Vida actual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida del jugador
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Jugador recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
        Destroy(gameObject); // Destruir al jugador (puedes implementar reintentos o un Game Over aquí)
    }
}
