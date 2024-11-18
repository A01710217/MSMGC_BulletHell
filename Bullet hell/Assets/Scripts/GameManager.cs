using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int IndiceNivel;
    
    void Start()
    {
        Debug.Log("El script GameManager se ha iniciado");
    }

    void Update()
    {

    }

    // Esta función se llama cuando el jugador presiona el botón de inicio
    public void StartGame()
    {
        // Log para verificar si se presiona el botón
        Debug.Log("Botón de inicio presionado, cargando escena: " + IndiceNivel);

        // Cambiar a la escena del juego, usando el índice que hayas asignado en Unity
        SceneManager.LoadScene(IndiceNivel); // Asegúrate de que IndiceNivel es el índice correcto

        Debug.Log("¡El juego ha comenzado!");
    }


    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

