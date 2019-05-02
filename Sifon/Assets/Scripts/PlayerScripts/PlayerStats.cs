using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerData player;

    public float Health { get; set; }
    public string Name { get; set; }
    public float Score { get; set; }

    private void Start()
    {
        player = new PlayerData("Birdy", 200, 120);
        Health = player.PlayerHealth;
        Name = player.PlayerName;
        Score = 0;

    }

}
