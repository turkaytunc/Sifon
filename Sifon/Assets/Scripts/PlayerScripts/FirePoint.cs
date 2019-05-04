using UnityEngine;

public class FirePoint : MonoBehaviour
{  
    public Transform firePointTransform;
    public GameObject bullet;
    public bool FaceRight { get; set; } = true;

    private const float fireRate = 2f;
    private float timeToShoot = 0f;
    private PlayerInput playerInput;
    private Vector3 right, left, bulletDirection;


    void Start()
    {
        firePointTransform = transform.Find("FirePoint").transform;
        playerInput = GetComponent<PlayerInput>();
        timeToShoot = 1 / fireRate;
    }

    void Update()
    {

        timeToShoot = timeToShoot - Time.deltaTime;

        if (timeToShoot <= 0)
        {
            Shooting();
            timeToShoot = 1 / fireRate;
        }

        else if (timeToShoot > 0)
        {
            SingleShooting();
        }
    }

    public void Shooting()
    {
        if (playerInput.LeftMouseButton())
        {
            CreateBullet();
        }
    }

    public void SingleShooting()
    {
        if (playerInput.LeftMouseButtonDown())
        {
            CreateBullet();
        }
    }
    
    //merminin uzaydaki konumu ve rotasyonu ayarlanir ve mermi objesi olusturulur
    public void CreateBullet()
    {
        if (FaceRight)
        {
            bulletDirection = new Vector3(0f, 0f, -90f);
        }
        else if (!FaceRight)
        {
            bulletDirection = new Vector3(0f, 0f, 90f);
        }
        Instantiate(bullet, firePointTransform.position, Quaternion.Euler(bulletDirection));

    }
}
