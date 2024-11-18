using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo

    void Start()
    {
        // Asegurarse de que los aviones estén rotados correctamente al comenzar
        transform.rotation = Quaternion.Euler(0, 270, 0); // Rotar el avión para que mire hacia abajo
    }

    void Update()
    {
        // Mover el enemigo en la dirección local hacia adelante (que en este caso es hacia abajo)
        transform.Translate(transform.forward * speed * Time.deltaTime);  // Mover hacia abajo, siguiendo la dirección local del avión
    }

    void OnBecameInvisible()
    {
        // Destruir el enemigo cuando salga de la pantalla
        Destroy(gameObject);
    }
}
