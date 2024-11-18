using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 30f; // Salud del enemigo

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Salud del enemigo: " + health);

        // Si la salud es 0 o menor, el enemigo debe morir
        if (health <= 0)
        {
            Die();
        }
    }

    // Método que se llama cuando el enemigo muere
    private void Die()
    {
        Debug.Log("El enemigo ha muerto!");
        Destroy(gameObject);  // Destruir el objeto enemigo
    }

    // Método para destruir el enemigo cuando sale de la pantalla
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
