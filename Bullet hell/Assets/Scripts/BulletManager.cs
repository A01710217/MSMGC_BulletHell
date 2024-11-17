using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    public static Action OnBossBulletCountChanged; // Evento para balas del jefe
    public static Action OnPlayerBulletCountChanged; // Evento para balas del jugador

    private static int bossBullets; // Contador de balas activas del jefe
    private static int playerBullets; // Contador de balas activas del jugador

    // Métodos para las balas del jefe
    public static void AddBossBullet()
    {
        bossBullets++;
        OnBossBulletCountChanged?.Invoke(); // Notificar cambio
    }

    public static void RemoveBossBullet()
    {
        bossBullets = Mathf.Max(0, bossBullets - 1);
        OnBossBulletCountChanged?.Invoke(); // Notificar cambio
    }

    public static int GetBossBullets()
    {
        return bossBullets;
    }

    // Métodos para las balas del jugador
    public static void AddPlayerBullet()
    {
        playerBullets++;
        OnPlayerBulletCountChanged?.Invoke(); // Notificar cambio
    }

    public static void RemovePlayerBullet()
    {
        playerBullets = Mathf.Max(0, playerBullets - 1);
        OnPlayerBulletCountChanged?.Invoke(); // Notificar cambio
    }

    public static int GetPlayerBullets()
    {
        return playerBullets;
    }
}
