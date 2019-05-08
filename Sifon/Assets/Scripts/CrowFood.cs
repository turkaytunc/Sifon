using UnityEngine;

public class CrowFood : MonoBehaviour
{
    private PlayerStats playerStats;


    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();//player objesinin playerstats bilesenine referans
    }


    //player isimli obje ile temas edilirse kendni yok et
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerStats.Score += 5;
            Destroy(gameObject, 0.1f);
        }
    }
}
