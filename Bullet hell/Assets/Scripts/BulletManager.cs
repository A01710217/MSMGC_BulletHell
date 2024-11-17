using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    public static Action OnBulletCountChanged; // Evento para notificar cambios en el contador de balas

    private static int activeBullets; // Contador de balas activas

    // Método para incrementar el contador de balas activas
    public static void AddBullet()
    {
        activeBullets++;
        OnBulletCountChanged?.Invoke(); // Notificar cambio
    }

    // Método para decrementar el contador de balas activas
    public static void RemoveBullet()
    {
        activeBullets = Mathf.Max(0, activeBullets - 1); // Evitar valores negativos
        OnBulletCountChanged?.Invoke(); // Notificar cambio
    }

    // Método para obtener la cantidad de balas activas
    public static int GetActiveBullets()
    {
        return activeBullets;
    }
}
