using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    private Vector3 direction; // Dirección de movimiento
    private Collider bulletCollider; // Referencia al Collider de la bala
    private bool isRemoved = false; // Bandera para evitar múltiples colisiones

    private void Start()
    {
        // Obtener el componente Collider de la bala
        bulletCollider = GetComponent<Collider>();

        // Desactivar el Collider para evitar colisiones entre las balas
        if (bulletCollider != null)
        {
            bulletCollider.enabled = false; // Desactivar el Collider
        }

        // Registrar la bala al iniciar
        BulletManager.AddBullet();
    }

    void Update()
    {
        // Mover la bala en la dirección especificada
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
