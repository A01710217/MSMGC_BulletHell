using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public float damage = 10f; // Daño que inflige la bala
    private Vector3 direction; // Dirección de movimiento
    private Collider bulletCollider; // Referencia al Collider de la bala
    private bool isRemoved = false; // Bandera para evitar múltiples colisiones

    private void Start()
    {
        // Obtener el componente Collider de la bala
        bulletCollider = GetComponent<Collider>();

        // Asegurarse de que el Collider esté habilitado
        if (bulletCollider != null)
        {
            bulletCollider.enabled = true; // Habilitar el Collider
        }

        // Registrar la bala al iniciar
        BulletManager.AddBullet();
    }

    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name);

        // Verificar si el objeto con el que colisionó es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡La bala tocó al jugador!");
            // Infligir daño al jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destruir la bala después del impacto
            Destroy(gameObject);
        }

        // Verificar si el objeto con el que colisionó es una bala del jugador
        if (other.CompareTag("PlayerBullet"))
        {
            // Destruir ambas balas al colisionar
            Destroy(other.gameObject);  // Destruir la bala del jugador
            Destroy(gameObject);  // Destruir la bala del jefe
        }
    }

    private void OnBecameInvisible()
    {
        // Remover la bala antes de destruirla
        RemoveBullet();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // Asegurar que la bala se remueva del contador al ser destruida
        RemoveBullet();
    }

    private void RemoveBullet()
    {
        if (!isRemoved)
        {
            BulletManager.RemoveBullet();
            isRemoved = true; // Marcar como eliminada
        }
    }

    // Método para establecer la dirección y velocidad
    public void SetDirection(Vector3 newDirection, float newSpeed)
    {
        direction = newDirection.normalized;
        speed = newSpeed;
    }
}
