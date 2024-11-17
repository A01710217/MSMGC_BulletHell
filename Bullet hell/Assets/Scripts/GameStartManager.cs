using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted = false;
    public GameObject homeScreenCanvas; // Canvas del menú inicial.
    public GameObject gameCanvas; // Canvas del juego.
    public Camera menuCamera; // Cámara del menú inicial.
    public Camera mainCamera; // Cámara principal del juego.

    void Start()
    {
        // Asegurarse de que todo esté en el estado correcto al inicio.
        Time.timeScale = 0; // Pausar el juego.
        homeScreenCanvas.SetActive(true); // Mostrar menú inicial.
        gameCanvas.SetActive(false); // Ocultar Canvas del juego.
        menuCamera.gameObject.SetActive(true); // Activar cámara del menú.
        mainCamera.gameObject.SetActive(false); // Desactivar cámara principal.
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
        mainCamera.gameObject.SetActive(true);

        Debug.Log("¡El juego ha comenzado!");
    }
}
