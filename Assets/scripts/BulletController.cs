using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float damage;
    private float startHeight;

    void Start()
    {
        startHeight = transform.position.y;
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.y = startHeight + 1;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            // Récupérer le script de l'ennemi
            EnnemyController enemyScript = collision.gameObject.GetComponent<EnnemyController>();
            if (enemyScript != null)
            {
                float xpGained = enemyScript.xpGiven;

                // Trouver le joueur et lui donner de l'XP
                PlayerController player = FindObjectOfType<PlayerController>();
                if (player != null)
                {
                    player.GainXP(xpGained);
                    if (player.xp_actual >= player.xp_needed) {
                        Debug.Log("je suis là");;
                        player.GainLvl();
                    } 
                     // <------------------------------------
                }
            }

            Destroy(collision.gameObject); // Supprimer l'ennemi
            Destroy(gameObject);           // Supprimer la balle
        }
    }
}
