using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFood : MonoBehaviour
{
    private PlayerStats playerStats;
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    
    void Update()
    {
        
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.2f);
            playerStats.Score += 5;

        }
    }
}
