using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
 
    public GameObject playerObject;




    private void Awake()
    {
        Debug.Log(PlayerData.PlayerName);
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
        playerObject.transform.position = new Vector3(PlayerData.PlayerXPos, PlayerData.PlayerYPos, PlayerData.PlayerZPos);
        Debug.Log(playerObject.transform.position);
      
        Show();
        Instantiate(playerObject, playerObject.transform.position, Quaternion.identity);

    }


    public void Show()
    {
        PlayerData.PlayerName = "Haso";
        Debug.Log(PlayerData.PlayerName);
    }

    private void SetPlayerTransform()
    {
        
        
    }

    

  
}
