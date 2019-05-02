public class PlayerData
{
    private  string playerName;
   
    private  float playerHealth;      
    public   float PlayerMovementSpeed { get; set; }
             
    public   float PlayerXPos { get; set; }
    public   float PlayerYPos { get; set; }
    public   float PlayerZPos { get; set; }


    public PlayerData(string playerName, float playerHealth, float PlayerMovementSpeed)
    {
        PlayerName = playerName;
        PlayerHealth = playerHealth;
        
        PlayerXPos = 0;
        PlayerYPos = 0;
        PlayerZPos = 0;
    }


    public  string PlayerName
    {        
        get
        {
            return playerName;
        }
        set
        {
            if(value != null && value.Length > 4 && value.Length < 10)
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
                playerHealth = 100;
            }
        }
    }  
}
