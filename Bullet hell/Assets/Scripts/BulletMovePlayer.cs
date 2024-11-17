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

    private void OnBecameInvisible()
    {
        // Destruir la bala cuando salga de la pantalla
        Destroy(gameObject);
    }
}
