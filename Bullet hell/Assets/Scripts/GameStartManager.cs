using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public static bool isGameStarted = false;
    public GameObject homeScreenCanvas; // Canvas del menú inicial.
    public GameObject gameCanvas; // Canvas del juego.
    public Camera menuCamera; // Cámara del menú inicial.
    public Camera level1Camera; // Cámara principal del juego.
    public Camera bossCamera; // Cámara para el nivel del jefe.
    public GameObject player; // Referencia al objeto jugador.

    public float timeToBossLevel = 30f; // Tiempo en segundos para llegar al nivel del jefe.
    private float timer = 0f; // Temporizador del juego.

    void Start()
    {
        // Asegurarse de que todo esté en el estado correcto al inicio.
        Time.timeScale = 0; // Pausar el juego.
        homeScreenCanvas.SetActive(true); // Mostrar menú inicial.
        gameCanvas.SetActive(false); // Ocultar Canvas del juego.
        menuCamera.gameObject.SetActive(true); // Activar cámara del menú.
        level1Camera.gameObject.SetActive(false); // Desactivar cámara principal.
        bossCamera.gameObject.SetActive(false); // Desactivar cámara del jefe.
    }

    void Update()
    {
        if (isGameStarted)
        {
            timer += Time.deltaTime; // Aumentar el temporizador con el tiempo transcurrido.

            // Comprobar si ya ha pasado el tiempo para cambiar al nivel del jefe.
            if (timer >= timeToBossLevel)
            {
                SwitchToBossLevel();
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1; // Reanudar el juego.

        // Ocultar el menú y mostrar el juego.
        homeScreenCanvas.SetActive(false);
        gameCanvas.SetActive(true);

        // Cambiar de cámaras.
        menuCamera.gameObject.SetActive(false);
        level1Camera.gameObject.SetActive(true);

        // Asegurarse de que el jugador esté en la escena y activado.
        player.SetActive(true);
        player.transform.position = new Vector3(-300, 0, -10); // Posición inicial del jugador.

        Debug.Log("¡El juego ha comenzado!");
    }

    void SwitchToBossLevel()
    {
        // Cambiar las cámaras sin activar al jefe.
        level1Camera.gameObject.SetActive(false);
        bossCamera.gameObject.SetActive(true);

        // Desactivar el Rigidbody mientras se mueve
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Desactivar física temporalmente
        }

        // Mover al jugador a la posición deseada
        player.transform.position = new Vector3(0, 1, -20);

        // Asegúrate de reactivar la física después de mover al jugador
        if (rb != null)
        {
            rb.isKinematic = false; // Reactivar física
        }

        Debug.Log("Cambiando al nivel del jefe (sin activar mecánicas).");
    }

}
