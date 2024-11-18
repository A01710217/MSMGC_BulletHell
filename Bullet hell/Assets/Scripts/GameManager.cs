using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool StartGame;
    public int IndiceNivel;

    void Update()
    {
        
    }

    public void ChangeScreen(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
