using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    private float fireRate = 2f;
    private float timeToShoot = 0f;
    public Transform firePointTransform;
    public GameObject bullet;
    private PlayerInput playerInput;
    private Vector3 right, left, bulletDirection;
    public bool FaceRight { get; set; }


    void Start()
    {
        firePointTransform = transform.Find("FirePoint").transform;
        playerInput = GetComponent<PlayerInput>();
        timeToShoot = 1 / fireRate;
    }
    
    void Update()
    {

        timeToShoot = timeToShoot - Time.deltaTime;
        
        if(timeToShoot <= 0)
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
