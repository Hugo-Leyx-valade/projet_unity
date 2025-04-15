// Script projectile.cs
using UnityEngine;
public class Dprojectile : MonoBehaviour
{
    void Start() {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // infliger des dégâts ici
            Destroy(gameObject);
        }
    }
}
