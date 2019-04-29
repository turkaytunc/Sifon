using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
 
    [SerializeField]private GameObject playerObject;
    [SerializeField]private GameObject killZoneObject;
    [SerializeField]private GameObject mainCameraObject;

    private PlayerData player;
    public Vector3 playerCurrentPosition { get; set; }

    //Singleton: oyunda tek bir tane GameMaster objesi olmasinin garanti altina alinmasi
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
    }

    private void Update()
    {
        CreatePlayer();

        CheckSceneEntities();

    }

    //Oyunda olusturulacak objelerin uzaydaki konumlarinin ayarlanmasi
    private void SetObjectTransform(Vector3 newPosition, GameObject newGameObject)
    {
        newGameObject.transform.position = newPosition;
    }

    //Yok edilen oyun objelerinin yerine yenilerinin olusturulmasi
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

    //player objesi ilk defa yaratiliyorsa konumu yaratilan nesneden al aksi halde olen karakterin eski baslangic konumunu kullan
    private void CreatePlayer()
    {
        if (playerCurrentPosition == null)
        {
            Vector3 playerPosition = new Vector3(player.PlayerXPos, player.PlayerYPos, player.PlayerZPos);
            SetObjectTransform(playerPosition, playerObject);
        }
        else
        {
            SetObjectTransform(playerCurrentPosition, playerObject);
        }
    }

    


}
