using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnRate = 1f;       // Temps minimum entre spawns
    public float maxSpawnRate = 3f;       // Temps maximum entre spawns
    public float minSpawnDistance = 5f;   // Distance minimum du joueur
    public float maxSpawnDistance = 15f;  // Distance maximum du joueur
    public Transform player;

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

        // Direction aléatoire dans le plan XZ
        Vector3 direction = Random.onUnitSphere;
        direction.y = 0f;

        // Distance aléatoire
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPos = player.position + direction.normalized * randomDistance;
        spawnPos.y = transform.position.y;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}