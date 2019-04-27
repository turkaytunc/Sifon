using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
 
    [SerializeField]
    private GameObject playerObject;

    private PlayerData player;


    //Singleton: Hierarchy de tek bir GameMaster objesi olmasinin garanti altina alinmasi
    private void Awake()
    {
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
        player = new PlayerData();
        
        Debug.Log(player.PlayerXPos);
        Debug.Log(player.PlayerHealth);
        
        SetPlayerTransform();

        Instantiate(playerObject, playerObject.transform.position, Quaternion.identity);
        
    }


    private void SetPlayerTransform()
    {
        playerObject.transform.position = new Vector3(player.PlayerXPos, player.PlayerYPos, player.PlayerZPos);
    }

}
