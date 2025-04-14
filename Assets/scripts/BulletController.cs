using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Windows.Speech;

public class BulletController : MonoBehaviour
{

    public float speed; 
    void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnColisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ennemy"){
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}