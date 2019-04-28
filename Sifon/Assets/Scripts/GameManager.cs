using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
 
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject killZoneObject;
    [SerializeField]
    private GameObject mainCameraObject;

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
        

        SetObjectTransform(player.PlayerXPos, player.PlayerYPos, player.PlayerZPos, playerObject);

        
        
    }


    private void Update()
    {
        CheckSceneEntities();
    }




    //Oyunda olusturulacak objelerin uzaydaki konumlarinin ayarlanmasi
    private void SetObjectTransform(float x, float y, float z, GameObject newGameObject)
    {
        newGameObject.transform.position = new Vector3(x, y, z);
    }



    private void CheckSceneEntities()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            Instantiate(playerObject, playerObject.transform.position, Quaternion.identity);
        }
        if (GameObject.FindWithTag("MainCamera") == null)
        {
            Instantiate(mainCameraObject, new Vector3(0, 3, -10), Quaternion.identity);
        }
        if (GameObject.FindWithTag("KillZone") == null)
        {
            Instantiate(killZoneObject, transform.position, Quaternion.identity);
        }
    }


}
