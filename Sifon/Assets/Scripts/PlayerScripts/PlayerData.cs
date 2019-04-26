
public static class PlayerData
{
    private static string playerName;
    private static float PlayerHealth { get; set; } = 100;
    private static float PlayerMovementSpeed { get; set; }
    public static float PlayerXPos { get; set; } = 0;
    public static float PlayerYPos { get; set; } = 0;
    public static float PlayerZPos { get; set; } = 0;

    

    public static string PlayerName
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
    

}
