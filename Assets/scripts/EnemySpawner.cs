using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;        // Le modèle d’ennemi à instancier
    public float spawnRate = 1.5f;        // Temps entre chaque spawn
    public float spawnDistance = 10f;     // Distance autour du joueur
    public Transform player;              // Référence au joueur (à auto-trouver ou drag-drop)

    void Start()
    {
        // Trouve le joueur si la référence n'est pas déjà définie dans l'inspecteur
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

        // Lance le spawn régulier
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Crée une direction aléatoire dans le plan XZ
        Vector3 direction = Random.onUnitSphere;
        direction.y = 0f; // Garde la hauteur constante

        // Calcule la position de spawn à la même hauteur que le spawner
        Vector3 spawnPos = player.position + direction.normalized * spawnDistance;
        spawnPos.y = transform.position.y;

        // Instancie l’ennemi à cette position
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
