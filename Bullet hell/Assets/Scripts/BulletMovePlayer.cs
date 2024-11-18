using UnityEngine;

public class BulletMovePlayer : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    private Vector3 direction; // Dirección de movimiento

    private void Start()
    {
        // Registrar la bala en el BulletManager
        BulletManager.AddPlayerBullet();
    }

    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 newDirection, float newSpeed)
    {
        direction = newDirection.normalized;
        speed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si la bala tocó un enemigo o un jefe
        if (other.CompareTag("Enemy"))
        {
            // Detectamos que tocó un enemigo normal
            Debug.Log("¡La bala del jugador tocó un enemigo!");

            // Intentamos obtener el script de salud del enemigo
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10f);  // Aplica daño al enemigo
            }

            // Destruir la bala
            Destroy(gameObject);
        }

        // Verificamos si la bala tocó un jefe
        if (other.CompareTag("Boss"))
        {
            // Detectamos que tocó un jefe
            Debug.Log("¡La bala del jugador tocó al jefe!");

            // Intentamos obtener el script de salud del jefe
            BossController bossController = other.GetComponent<BossController>();
            if (bossController != null)
            {
                bossController.TakeDamage(10f);  // Aplica daño al jefe
            }

            // Destruir la bala
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruir la bala cuando se haga invisible
    }

    private void OnDestroy()
    {
        // Notificar al BulletManager que la bala fue destruida
        BulletManager.RemovePlayerBullet();
    }
}
