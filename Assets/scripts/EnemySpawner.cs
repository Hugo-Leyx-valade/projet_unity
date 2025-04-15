using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnRate = 1f;       // Temps minimum entre spawns
    public float maxSpawnRate = 5f;       // Temps maximum entre spawns
    public float minSpawnDistance = 8f;   // Distance minimum du joueur
    public float maxSpawnDistance = 15f;  // Distance maximum du joueur
    public Transform player;

    public float followHeight=-10f;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Aucun joueur avec le tag 'Player' trouvé !");
                return;
            }
        }

        // Lance la coroutine de spawn
        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            SpawnEnemy();

            // Attente aléatoire avant le prochain spawn
            float waitTime = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Direction aléatoire dans le plan XZ uniquement
        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f; // important : on reste dans le plan horizontal

        // Calcul de la position
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPos = player.position + direction.normalized * randomDistance;

        // Fixe la hauteur de spawn
        spawnPos.y = 0f;  // ou une valeur fixe, genre 1.5f

        // Crée l'ennemi
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}