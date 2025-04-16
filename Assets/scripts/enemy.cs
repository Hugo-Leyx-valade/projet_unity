using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float xp_given = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}