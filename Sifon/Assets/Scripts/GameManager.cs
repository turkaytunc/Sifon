using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
 
    [SerializeField]
    private GameObject playerObject;


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
        SetPlayerTransform();
        Debug.Log(playerObject.transform.position);

        Instantiate(playerObject, playerObject.transform.position, Quaternion.identity);

    }


    private void SetPlayerTransform()
    {
        playerObject.transform.position = new Vector3(PlayerData.PlayerXPos, PlayerData.PlayerYPos, PlayerData.PlayerZPos);
    }




}
