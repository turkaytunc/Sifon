using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerData player;

    public float Health { get; set; }
    public string Name { get; set; }
    public float Score { get; set; }

    private void Start()
    {
        player = new PlayerData("Birdy", 100, 120);
        Health = player.PlayerHealth;
        Name = player.PlayerName;
        Score = 0;
        
    }
    private void Update()
    {
        if (Health <= 0 || transform.position.y < -15)
        {
            transform.position = new Vector3(0, 2, 0);
            Health = 100;
            if(Score <= 20)
            {
                Score = 0;
            }
            else
                Score -= 20;
        }
    }

}
