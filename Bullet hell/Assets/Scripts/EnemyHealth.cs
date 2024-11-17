using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Salud máxima del enemigo
    private float currentHealth; // Salud actual

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Jefe recibió daño. Salud restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Si la salud llega a cero, el jefe muere
        }
    }

    private void Die()
    {
        Debug.Log("¡El jefe ha muerto!");
        Destroy(gameObject); // Destruir el objeto del jefe (o puedes hacer otro tipo de acción)
    }
}
