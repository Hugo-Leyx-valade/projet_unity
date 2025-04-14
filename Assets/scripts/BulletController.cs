using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position+=Vector3.forward*speed*Time.deltaTime;
    }
}
