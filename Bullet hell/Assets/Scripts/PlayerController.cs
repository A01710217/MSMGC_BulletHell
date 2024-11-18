using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float slowSpeedMultiplier = 0.5f;  // Multiplicador de velocidad cuando se presiona Shift
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform bulletSpawnPoint; // Punto desde donde se dispara la bala
    public float bulletSpeed = 10f; // Velocidad de la bala

    // Cooldown para disparar
    public float shootCooldown = 0.5f; // Tiempo entre disparos (en segundos)
    private float lastShootTime; // Tiempo del último disparo

    private PlayerHealth playerHealth;  // Referencia al script de salud del jugador

    void Start()
    {
        // Obtener el componente PlayerHealth
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // Detectar si la tecla Shift está presionada
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        // Ajustar la velocidad dependiendo de si Shift está presionado
        float currentSpeed = isShiftPressed ? speed * slowSpeedMultiplier : speed;

        // Mover el vehículo de izquierda a derecha
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        // Mover el vehículo de arriba a abajo
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);

        // Disparar al presionar la tecla K, respetando el cooldown
        if (Input.GetKeyDown(KeyCode.K) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    // Método para disparar
    void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Crear la bala en el punto de disparo
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Configurar la velocidad y dirección de la bala
            BulletMovePlayer bulletScript = bullet.GetComponent<BulletMovePlayer>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(transform.forward, bulletSpeed);
            }

            // Registrar el tiempo del disparo actual
            lastShootTime = Time.time;
        }
        else
        {
            Debug.LogWarning("Prefab de bala o punto de disparo no asignados.");
        }
    }

    // Detecta las colisiones con los enemigos si los Colliders están en modo Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡El jugador ha chocado con un enemigo!");

            // Aplicar daño al jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10f);  // Reducir la salud del jugador
            }

            // Destruir el enemigo después de la colisión
            Destroy(other.gameObject);
        }
    }

    // Método para mover al jugador a la posición deseada en el nivel del jefe
    public void MoveToBossLevel(Vector3 targetPosition)
    {
        // Mover al jugador directamente a la nueva posición sin usar Rigidbody
        transform.position = targetPosition;
    }
}
