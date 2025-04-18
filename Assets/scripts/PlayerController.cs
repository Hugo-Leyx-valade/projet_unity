using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI levelTextTMP;
    public int maxHealth=100;
    public int currentHealth=100;
    public Image lifelineImage;
    public int niveau;
    public float xp_actual;
    public float xp_needed = 100;
    
    

    
    public int levelForMultiShot = 6;

    public float multiShotSpreadAngle = 30f;
    public int numberOfShots = 5;
    public GameObject bulletPrefab;

    public GameObject gameOverScreen;
    
    private Rigidbody _rb;
    
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform teleportDestination1;
    public Transform teleportDestination2;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        mainCamera = FindAnyObjectByType<Camera>();
        UpdateHealthUI();
        if (levelTextTMP != null)
            levelTextTMP.text = "Niveau : " + niveau;

        if (levelTextTMP != null)
            levelTextTMP.text = "Niveau : " + niveau;
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 myVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            myVector += Vector3.forward;

            //this.transform.position+=Vector3.forward* speed* Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            myVector += Vector3.back;
        }
        if(Input.GetKey(KeyCode.A)){
            myVector += Vector3.left;
        }
        if(Input.GetKey(KeyCode.D)){
            myVector += Vector3.right;
        }
        _rb.linearVelocity= myVector * speed;

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            
            // On récupère le script BulletController pour lui assigner les dégâts
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            
            if (bulletScript != null)
            {
                // Exemple : les dégâts augmentent avec le niveau
                bulletScript.damage = 10 * niveau;
            }
        }
        if (niveau >= levelForMultiShot && Input.GetKeyDown(KeyCode.E))
        {
            ShootMultipleBullets();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            currentHealth-=10;
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

    public void GainXP(float amount)
    {
        xp_actual += amount;
        Debug.Log("XP gagné : " + amount + " | XP total : " + xp_actual);
        
    }
    public void GainLvl(){
         this.niveau +=1;
        Debug.Log(this.niveau);
        this.xp_actual=0;
        this.xp_needed+=niveau*27;

        // MAJ texte
        if (levelTextTMP != null)
            levelTextTMP.text = "Niveau : " + niveau;

        if (levelTextTMP != null)
         levelTextTMP.text = "Niveau : " + niveau;

        if(this.niveau==3){
            speed=8;
        }
    }
    void UpdateHealthUI()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        lifelineImage.fillAmount = fillAmount;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            // Vérifie la position actuelle pour déterminer la destination
            if (transform.position.z > teleportDestination2.position.z) // Assurez-vous que cela correspond à votre logique
            {
                transform.position = teleportDestination2.position;
            }
            else
            {
                transform.position = teleportDestination1.position;
            }

            // Réinitialise la vélocité après la téléportation si nécessaire
            _rb.linearVelocity = Vector3.zero;
        }
    }
    void ShootMultipleBullets()
    {
        float angleStep = multiShotSpreadAngle / (numberOfShots - 1);
        float startingAngle = -multiShotSpreadAngle / 2;

        for (int i = 0; i < numberOfShots; i++)
        {
            float angle = startingAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, rotation);
            
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            if (bulletScript != null)
            {
                bulletScript.damage = 10 * niveau; // Peut être adapté
            }
        }
    }
}

