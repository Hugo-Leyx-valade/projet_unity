using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // On déplace le joueur selon l’orientation
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);
    }
}