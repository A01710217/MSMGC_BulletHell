using UnityEngine;
using TMPro;

public class BulletUI : MonoBehaviour
{
    public TextMeshProUGUI bossBulletText; // Texto para balas del jefe
    public TextMeshProUGUI playerBulletText; // Texto para balas del jugador

    private void OnEnable()
    {
        BulletManager.OnBossBulletCountChanged += UpdateBossBulletCount;
        BulletManager.OnPlayerBulletCountChanged += UpdatePlayerBulletCount;
    }

    private void OnDisable()
    {
        BulletManager.OnBossBulletCountChanged -= UpdateBossBulletCount;
        BulletManager.OnPlayerBulletCountChanged -= UpdatePlayerBulletCount;
    }

    private void UpdateBossBulletCount()
    {
        bossBulletText.text = $"{BulletManager.GetBossBullets()}";
    }

    private void UpdatePlayerBulletCount()
    {
        playerBulletText.text = $"{BulletManager.GetPlayerBullets()}";
    }
}
