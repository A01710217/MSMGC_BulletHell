using UnityEngine;

public class BossController : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jefe
    private float currentHealth; // Vida actual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida del jefe
    }

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Jefe recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("¡El jefe ha sido derrotado!");
        Destroy(gameObject); // Destruir al jefe al morir
    }
}
