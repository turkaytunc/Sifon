using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;

    private PlayerInput playerInput;
    private Transform menuPanel;
    private PlayerMovementControl movementControl;
    private PlayerStats playerStats;
    private Vector3 playerCurrentPosition;
    private float playerCurrentHealth;
    private string json;
    private string loadedString;

    //Oyunda tek bir tane Canvas olmasini sagla
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
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        movementControl = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        menuPanel = transform.Find("MenuPanel");
        menuPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(movementControl == null)
        {
            movementControl = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        }
        if (playerInput.KButtonDown())
        {
            playerStats.Health += 5;
        }

        playerCurrentHealth = playerStats.Health;
        playerCurrentPosition = movementControl.transform.position;

        HandleUI();

        MainMenu();
        
    }

    public void SaveGameButton()
    {
        SaveObject saveObject = new SaveObject
        {
            playerPosition = playerCurrentPosition,
            score = transform.Find("ScoreText").gameObject.GetComponent<Text>().text,
            playerHealth = playerCurrentHealth
        };

        json = JsonUtility.ToJson(saveObject);
        SaveLoadHandler.SaveString(json);



        //YAPILACAK: Oyunun kaydedildigine dair bilgiyi ekranda gostermek icin ui eklemesi yap
        Debug.Log("Game Saved");
    }

    public void LoadGameButton()
    {
        loadedString = SaveLoadHandler.LoadString();
        SaveObject loadObject = JsonUtility.FromJson<SaveObject>(loadedString);

        movementControl.transform.position = loadObject.playerPosition;
        playerStats.Health = loadObject.playerHealth;
        playerStats.Score = float.Parse(loadObject.score);

        Debug.Log("Game Loaded");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }


    private void MainMenu()
    {
        if (playerInput.EscapeButtonDown())
        {
            if (!menuPanel.gameObject.activeInHierarchy)
            {
                menuPanel.gameObject.SetActive(true);
            }
            else
            {
                menuPanel.gameObject.SetActive(false);
            }
        }
    }

    private class SaveObject
    {
        public Vector3 playerPosition;
        public string score;
        public float playerHealth;
    };


    private void HandleUI()
    {

        transform.Find("PlayerHealth").gameObject.GetComponent<Text>().text = playerStats.Health.ToString();
        transform.Find("ScoreText").gameObject.GetComponent<Text>().text = playerStats.Score.ToString();

    }

}
