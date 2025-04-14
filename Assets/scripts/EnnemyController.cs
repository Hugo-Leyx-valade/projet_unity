using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnnemyController : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
