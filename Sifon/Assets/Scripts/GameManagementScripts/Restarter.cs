using UnityEngine;
using UnityEngine.SceneManagement;


public class Restarter : MonoBehaviour
{
    //Karakter bosluga duser ise oyunu yeniden baslat
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.Health = 100;
        if (other.tag == "Player")
        {
          
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

}

