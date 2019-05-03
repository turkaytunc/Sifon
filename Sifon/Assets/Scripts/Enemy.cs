using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;
    public RaycastHit2D groundInfo;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D bullet)
    {
        if(bullet.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            playerStats.Score += 10;
        }
        
    }

    public void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            playerStats.Health -= 20;
        }
    }
}

