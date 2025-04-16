using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public float speed;
    public int maxHealth=100;
    public int currentHealth=100;


    public GameObject bulletPrefab;

    public GameObject gameOverScreen;
    
    private Rigidbody _rb;
    public Image lifelineImage;
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        mainCamera = FindAnyObjectByType<Camera>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.W)){
            this.transform.position+=Vector3.forward* speed* Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            this.transform.position+=Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            this.transform.position+=Vector3.left * speed * Time.deltaTime;
        }
         if(Input.GetKey(KeyCode.D)){
            this.transform.position+=Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bulletPrefab, transform.position, transform.rotation);        
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            currentHealth -=10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthUI();
            Destroy(collision.gameObject);
            if(currentHealth==0){
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
            }
            
        }
    }
    
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(inputX, 0.0f, inputY);
        _rb.AddForce(movement);
        //Face muse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    void UpdateHealthUI()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        lifelineImage.fillAmount = fillAmount;
    }

}
