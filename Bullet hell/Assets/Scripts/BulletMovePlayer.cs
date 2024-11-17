using UnityEngine;

public class BulletMovePlayer : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    private Vector3 direction; // Dirección de movimiento

    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Método para establecer la dirección y velocidad
    public void SetDirection(Vector3 newDirection, float newSpeed)
    {
        direction = newDirection.normalized;
        speed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala del jugador colisiona con el jefe
        if (other.CompareTag("Enemy"))
        {
            // Mostrar mensaje de colisión
            Debug.Log("¡La bala del jugador tocó al jefe!");
            // Aplicar daño al jefe
            BossController bossController = other.GetComponent<BossController>();
            if (bossController != null)
            {
                bossController.TakeDamage(10f); // Ajusta el valor de daño
            }

            // Destruir la bala del jugador
            Destroy(gameObject); // Destruir la bala
        }
    }

    private void OnBecameInvisible()
    {
        // Destruir la bala cuando salga de la pantalla
        Destroy(gameObject);
    }
}
