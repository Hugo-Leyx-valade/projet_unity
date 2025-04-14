using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    private float startHeight; // Stocke la hauteur de départ

    void Start()
    {
        // Sauvegarde la hauteur initiale
        startHeight = transform.position.y;

        // Détruit le projectile après un certain temps
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        // Avance vers l'avant
        transform.position += transform.forward * speed * Time.deltaTime;

        // Reste à la hauteur de départ
        Vector3 pos = transform.position;
        pos.y = startHeight+1;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
