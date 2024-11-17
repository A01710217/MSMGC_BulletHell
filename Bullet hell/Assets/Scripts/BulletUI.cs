using UnityEngine;
using TMPro;

public class BulletUI : MonoBehaviour
{
    public TextMeshProUGUI bulletText; // Referencia al objeto de texto

    private void OnEnable()
    {
        BulletManager.OnBulletCountChanged += UpdateBulletCount; // Suscribirse al evento
    }

    private void OnDisable()
    {
        BulletManager.OnBulletCountChanged -= UpdateBulletCount; // Desuscribirse del evento
    }

    private void UpdateBulletCount()
    {
        // Actualizar el texto con la cantidad de balas activas
        bulletText.text = $"{BulletManager.GetActiveBullets()}";
    }
}
