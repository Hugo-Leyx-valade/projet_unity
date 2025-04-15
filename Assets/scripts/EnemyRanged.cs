using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public Transform player;
    public float detectionRange ;
    public float stopDistance ; // Distance de tir
    public float speed = 3f;
    public float followHeight = 1f;
    public float xp_given = 10f;


    public GameObject projectilePrefab;
    public float shootCooldown = 2f;

    private float shootTimer = 0f;
    private bool isAggro = false;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans la zone de détection
        if (distance <= detectionRange)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            // Si trop loin, se rapprocher
            if (distance > stopDistance)
            {
                Vector3 targetPos = new Vector3(player.position.x, followHeight, player.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }

            // Toujours orienté vers le joueur
            Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookAtTarget);

            // Si à bonne distance, attaquer
            if (distance <= stopDistance)
            {
                shootTimer -= Time.deltaTime;
                if (shootTimer <= 0f)
                {
                    Shoot();
                    shootTimer = shootCooldown;
                }
            }
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null)
        {
            GameObject proj = Instantiate(projectilePrefab, transform.position + transform.forward * 1.5f, Quaternion.identity);
            proj.GetComponent<Rigidbody>().linearVelocity = transform.forward * 10f;
        }
    }
}
