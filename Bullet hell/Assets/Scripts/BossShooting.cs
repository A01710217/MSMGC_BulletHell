using System.Collections;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public float fireRate = 1f;      // Frecuencia de disparo en segundos
    public float bulletSpeed = 10f;  // Velocidad de la bala
    public int numberOfBullets = 10; // Número de balas para disparos en círculo/estrella

    private Coroutine shootCoroutine;

    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        // Disparo en línea (0-10 minutos)
        if (TimeManager.Minute == 1 && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootLine());
        }
        if (TimeManager.Minute == 10 && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            Debug.Log("Finalizando disparo de línea...");
            shootCoroutine = null;
        }

        // Disparo en círculo (10-20 minutos)
        if (TimeManager.Minute == 10 && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootCircle());
        }

        if (TimeManager.Minute == 20 && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            Debug.Log("Finalizando disparo en círculo...");
            shootCoroutine = null;
        }

        // Disparo en estrella (20-30 minutos)
        if (TimeManager.Minute == 20 && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootStar());
        }
        if (TimeManager.Minute == 30 && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            Debug.Log("Finalizando disparo en estrella...");
            shootCoroutine = null;
        }

        //Disparo en espiral (30-40 minutos)
        if (TimeManager.Minute == 30 && shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootSpiral());
        }

        if (TimeManager.Minute == 40 && shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            Debug.Log("Finalizando disparo en espiral...");
            shootCoroutine = null;
        }
        
    }

    private IEnumerator ShootLine()
    {
        Debug.Log("Iniciando disparo de línea...");
        float elapsedTime = 0f;
        float shootDuration = 10f;

        while (elapsedTime < shootDuration)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
            if (bulletScript != null)
            {
                bulletScript.speed = bulletSpeed;
            }

            yield return new WaitForSeconds(fireRate);
            elapsedTime += fireRate;
        }
    }

    private IEnumerator ShootCircle()
    {
        Debug.Log("Iniciando disparo en círculo...");

        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        while (true) // Esto hará que el disparo en círculo ocurra de manera continua
        {
            // Realizar el disparo de todas las balas en esta iteración
            for (int i = 0; i < numberOfBullets; i++)
            {
                // Calcular la dirección de la bala
                Vector3 bulletDirection = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

                // Instanciar la bala y establecer su dirección y velocidad
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, angle, 0));

                // Obtener el script de movimiento de la bala y establecer la dirección y velocidad
                BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();

                if (bulletScript != null)
                {
                    bulletScript.SetDirection(bulletDirection, bulletSpeed);
                }

                angle += angleStep;
            }

            //Esperar 1 segundos antes de disparar nuevamente
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ShootStar()
    {
        Debug.Log("Iniciando disparo en estrella...");
        float elapsedTime = 0f;
        float shootDuration = 10f;
        float angle = 0f;

        while (elapsedTime < shootDuration)
        {
            float angleStep = 360f / 5;  // Estrella con 5 balas

            for (int i = 0; i < 5; i++)
            {
                //Poner la bala en estrella
                Vector3 bulletDirection = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

                //Instanciar la bala y establecer su dirección y velocidad
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, angle, 0));

                //Obtener el script de movimiento de la bala y establecer la dirección y velocidad
                BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();

                if (bulletScript != null)
                {
                    bulletScript.SetDirection(bulletDirection, bulletSpeed);
                }

                angle += angleStep;
            }

            yield return new WaitForSeconds(fireRate);
            elapsedTime += fireRate;
        }
    }

    private IEnumerator ShootSpiral()
    {
        Debug.Log("Iniciando disparo en espiral...");
        float elapsedTime = 0f;
        float shootDuration = 10f;
        float angle = 0f;

        while (elapsedTime < shootDuration)
        {
            float angleStep = 360f / 20;  // Espiral con 100 balas

            for (int i = 0; i < 5; i++)
            {
                //Poner la bala en espiral
                Vector3 bulletDirection = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

                //Instanciar la bala y establecer su dirección y velocidad
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, angle, 0));

                //Obtener el script de movimiento de la bala y establecer la dirección y velocidad
                BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();

                if (bulletScript != null)
                {
                    bulletScript.SetDirection(bulletDirection, bulletSpeed);
                }

                angle += angleStep;

                yield return new WaitForSeconds(0.0001f);

            }

            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;

        }

    }
}
