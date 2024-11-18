using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float spawnRate = 2f; // Tiempo entre aparición de enemigos
    public float spawnXMin = -355f; // Valor mínimo en el eje X
    public float spawnXMax = -240f; // Valor máximo en el eje X
    public float spawnZ = 15f; // Valor fijo para la posición en el eje Z (parte superior de la pantalla)

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate); // Invocar la función repetidamente
    }

    void SpawnEnemy()
    {
        // Generar una posición aleatoria en el eje X entre los valores especificados
        float spawnX = Random.Range(spawnXMin, spawnXMax);

        // Definir la posición de aparición del enemigo, dejando el valor Z fijo en 15
        Vector3 spawnPosition = new Vector3(spawnX, 0f, spawnZ);

        // Crear el enemigo en esa posición
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
