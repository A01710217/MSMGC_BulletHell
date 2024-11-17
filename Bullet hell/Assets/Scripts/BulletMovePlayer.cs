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
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("¡La bala del jugador tocó al jefe!");
            BossController bossController = other.GetComponent<BossController>();
            if (bossController != null)
            {
                bossController.TakeDamage(10f);
            }

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // Notificar al BulletManager que la bala fue destruida
        BulletManager.RemovePlayerBullet();
    }
}
