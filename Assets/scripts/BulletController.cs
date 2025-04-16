<<<<<<< HEAD
=======
using System;
>>>>>>> 1a07ea81bb521abf2e77583cdc5c11907f024d47
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
<<<<<<< HEAD
    private float startHeight; // Stocke la hauteur de dÈpart

    void Start()
    {
        // Sauvegarde la hauteur initiale
        startHeight = transform.position.y;

        // DÈtruit le projectile aprËs un certain temps
=======
    public float damage;
    private float startHeight;

    void Start()
    {
        startHeight = transform.position.y;
>>>>>>> 1a07ea81bb521abf2e77583cdc5c11907f024d47
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
<<<<<<< HEAD
        // Avance vers l'avant
        transform.position += transform.forward * speed * Time.deltaTime;

        // Reste ‡ la hauteur de dÈpart
        Vector3 pos = transform.position;
        pos.y = startHeight+1;
=======
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.y = startHeight + 1;
>>>>>>> 1a07ea81bb521abf2e77583cdc5c11907f024d47
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
<<<<<<< HEAD
            Destroy(collision.gameObject);
            Destroy(gameObject);
=======
            // R√©cup√©rer le script de l'ennemi
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
                        Debug.Log("je suis l√†");;
                        player.GainLvl();
                    } 
                     // <------------------------------------
                }
            }

            Destroy(collision.gameObject); // Supprimer l'ennemi
            Destroy(gameObject);           // Supprimer la balle
>>>>>>> 1a07ea81bb521abf2e77583cdc5c11907f024d47
        }
    }
}
