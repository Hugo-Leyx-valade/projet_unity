using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;        // Le modèle d’ennemi à instancier
    public float spawnRate = 1.5f;        // Temps entre chaque spawn
    public float spawnDistance = 10f;     // Distance autour du joueur

    void Start()
    {
        // Appelle la fonction SpawnEnemy toutes les X secondes
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnRate);
    }

    void SpawnEnemy()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        if (player == null) return;

        // Crée une direction aléatoire dans le plan XZ (sol)
        Vector3 direction = Random.onUnitSphere;
        direction.y = 0; // Pas de variation verticale

        // Calcule la position d’apparition
        Vector3 spawnPos = player.position + direction.normalized * spawnDistance;

        // Instancie un nouvel ennemi
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}