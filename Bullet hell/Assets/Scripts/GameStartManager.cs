using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI Text

public class GameStartManager : MonoBehaviour
{
    public static bool isGameStarted = false;
    public GameObject homeScreenCanvas; // Canvas del menú inicial.
    public GameObject gameCanvas; // Canvas del juego.
    public Camera menuCamera; // Cámara del menú inicial.
    public Camera level1Camera; // Cámara principal del juego.
    public GameObject player; // Referencia al objeto jugador.

    public Text resultText; // Referencia al Text donde se muestra el resultado ("Ganaste" o "Perdiste").

    void Start()
    {
        // Asegurarse de que todo esté en el estado correcto al inicio.
        Time.timeScale = 0; // Pausar el juego.
        homeScreenCanvas.SetActive(true); // Mostrar menú inicial.
        gameCanvas.SetActive(false); // Ocultar Canvas del juego.
        menuCamera.gameObject.SetActive(true); // Activar cámara del menú.
        level1Camera.gameObject.SetActive(false); // Desactivar cámara principal.

        resultText.gameObject.SetActive(false); // Asegurarse de que el texto de resultado esté oculto al principio.
    }

    void Update()
    {
        // Aquí podrías poner lógica para determinar si el jugador ha ganado o perdido en función del juego.
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
        if (player != null)
        {
            player.SetActive(true);
            player.transform.position = new Vector3(-300, 0, -10); // Posición inicial del jugador.
            Debug.Log("¡El jugador está activo y listo!");
        }
        else
        {
            Debug.LogError("El objeto 'player' no está en la escena o ha sido destruido.");
        }

        Debug.Log("¡El juego ha comenzado!");
    }

    // Método para finalizar el juego con victoria
    public void Win()
    {
        resultText.text = "¡Ganaste!"; // Mostrar el mensaje de victoria.
        resultText.gameObject.SetActive(true); // Activar el texto de resultado.
        Time.timeScale = 0; // Pausar el juego.

        // Regresar a la cámara principal (nivel 1) después de ganar.
        level1Camera.gameObject.SetActive(true); // Activar la cámara principal.
        menuCamera.gameObject.SetActive(false); // Desactivar la cámara del menú.

        Debug.Log("¡El jugador ganó!");
    }

    // Método para finalizar el juego con derrota
    public void Lose()
    {
        resultText.text = "¡Perdiste!"; // Mostrar el mensaje de derrota.
        resultText.gameObject.SetActive(true); // Activar el texto de resultado.
        Time.timeScale = 0; // Pausar el juego.

        // Regresar a la cámara principal (nivel 1) después de perder.
        level1Camera.gameObject.SetActive(true); // Activar la cámara principal.
        menuCamera.gameObject.SetActive(false); // Desactivar la cámara del menú.

        Debug.Log("¡El jugador perdió!");
    }

    // Método para regresar al menú de inicio
    public void GoToMainMenu()
    {
        resultText.gameObject.SetActive(false); // Desactivar el texto de resultado.
        homeScreenCanvas.SetActive(true); // Mostrar el menú inicial.
        gameCanvas.SetActive(false); // Ocultar Canvas del juego.
        menuCamera.gameObject.SetActive(true); // Activar cámara del menú.
        level1Camera.gameObject.SetActive(false); // Desactivar cámara principal.

        Time.timeScale = 0; // Pausar el juego cuando regrese al menú.
    }
}
