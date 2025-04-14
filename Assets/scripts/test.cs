using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            this.transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A)){
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S)){
            this.transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
