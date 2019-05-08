using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 0.8f;
    private float distance = 0.5f;
    private bool movingRight = true;
    private float health = 100;

    [SerializeField]private Transform groundDetection;
    private RaycastHit2D groundInfo;
    private PlayerStats playerStats;
    
    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();// player isimli objenin uzerindeki PlayerStats componentine referans
    }
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        EnemyMovement();
    }
    //dusmanlarin hareketlerinin saglanmasi
    private void EnemyMovement()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);//yer yuzeyine bir isin yollanmasi
        Debug.DrawRay(groundDetection.position, Vector2.down, Color.red);

        //eger yollanan isin yere carpmiyor ise yaratigin gittigi yonu tersine cevir
        if (groundInfo.collider == false)
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

    //mermi ile etkilesim halinde kendini yok et
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if(bullet.gameObject.tag == "Bullet")
        {
            health -= 20;
            if(health <= 0)
            {
                playerStats.Score += 10;
                Destroy(gameObject);
            }
        }       
    }

    //oyuncu ile etkilesim halinde oyuncunun canini azalt
    private void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            playerStats.Health -= 10;
        }
    }
}

