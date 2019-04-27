
public class PlayerData
{
    private  string playerName;
    private  float playerHealth = 5;
             
    public   bool PlayerHasGun { get; set; } = false;
    public   float PlayerMovementSpeed { get; set; } = 120;
             
    public   float PlayerXPos { get; set; } = 0;
    public   float PlayerYPos { get; set; } = 0;
    public   float PlayerZPos { get; set; } = 0;

    


    public  string PlayerName
    {
        
        get
        {
            return playerName;
        }
        set
        {
            if(value != null)
            {
                playerName = value;

            }
            else
            {
                playerName = "NoName";
            }
        }
    }

    public  float PlayerHealth
    {
        get
        {
            return playerHealth;
        }

        set
        {
            if(value >= 0 && value <= 100)
            {
                playerHealth = value;
            }
            else
            {
                playerHealth = 1;
            }
        }
    }
    

}
