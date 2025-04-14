using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Windows.Speech;

public class BulletController : MonoBehaviour
{
<<<<<<< HEAD
    public float speed; 
=======
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
>>>>>>> 42b59b420b7dc1643d851c0c1c2520f39e83ec39
    void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ennemy"){
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
=======
        this.transform.position+=Vector3.forward*speed*Time.deltaTime;
>>>>>>> 42b59b420b7dc1643d851c0c1c2520f39e83ec39
    }
}

