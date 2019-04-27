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
        player = new PlayerData("Mahmut", 80, 120);
        Debug.Log(player.PlayerXPos);
        Debug.Log(player.PlayerHealth);
        Debug.Log(player.PlayerName);


        SetObjectTransform(player.PlayerXPos, player.PlayerYPos, player.PlayerZPos, playerObject);

        Instantiate(playerObject, playerObject.transform.position, Quaternion.identity);
        
    }




    //Oyunda olusturulacak objelerin uzaydaki konumlarinin ayarlanmasi
    private void SetObjectTransform(float x, float y, float z, GameObject newGameObject)
    {
        newGameObject.transform.position = new Vector3(x, y, z);
    }


}
