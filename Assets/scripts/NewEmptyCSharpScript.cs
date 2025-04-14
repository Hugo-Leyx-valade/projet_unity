using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Le joueur à suivre
    public Vector3 offset;         // Décalage de la caméra par rapport au joueur
    public float smoothSpeed = 0.125f;  // Vitesse de suivi

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Si tu veux que la caméra regarde toujours le joueur :
        // transform.LookAt(target);
    }
}
