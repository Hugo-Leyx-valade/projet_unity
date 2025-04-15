using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;        // Référence au joueur
    public float speed = 5f;        // Vitesse de déplacement
    public float followHeight = 1f; // Hauteur constante de la sphère

    void Start()
    {
        // Si le joueur n'est pas assigné dans l'inspecteur, on le cherche via son tag
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Aucun joueur trouvé avec le tag 'Player' !");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        // Position du joueur mais avec la hauteur de l'ennemi (suivi horizontal uniquement)
        Vector3 targetPosition = new Vector3(player.position.x, followHeight, player.position.z);

        // Déplacement fluide vers le joueur
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Orientation vers le joueur (optionnel)
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtTarget);
    }
}
