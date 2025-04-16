using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    public Transform player;        // R�f�rence au joueur
    public float speed = 5f;        // Vitesse de d�placement
    public float xpGiven = 50f;
    public float followHeight = -5f;
    private Animator animator;


    void Start()
    {
        // Si le joueur n'est pas assign� dans l'inspecteur, on le cherche via son tag
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Aucun joueur trouv� avec le tag 'Player' !");
            }
        }
        animator = GetComponent<Animator>();
        bool isMoving = true;
        animator.SetBool("isMoving", isMoving);
    }

    void Update()
    {
        if (player == null) return;

            // Position cible (même X et Z que le joueur, mais Y fixé à followHeight)
            Vector3 targetPosition = new Vector3(player.position.x, followHeight, player.position.z);

            // Déplacement horizontal uniquement, Y bloqué
            Vector3 newPosition = Vector3.MoveTowards(
            new Vector3(transform.position.x, followHeight, transform.position.z), // position actuelle avec Y figé
            targetPosition,
            speed * Time.deltaTime
        );

        transform.position = newPosition;

        // Orientation vers le joueur (ignore Y pour éviter de pencher)
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtTarget);
    }
}
