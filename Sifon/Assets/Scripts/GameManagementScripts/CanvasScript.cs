using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;

    private PlayerInput playerInput;
    private Transform menuPanel;
    private PlayerMovementControl movementControl;
    private Vector3 playerCurrentPosition;
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
        menuPanel = transform.Find("MenuPanel");
        menuPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(movementControl == null)
        {
            movementControl = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        }
        playerCurrentPosition = movementControl.transform.position;

        MainMenu();
        
    }

    public void SaveGameButton()
    {
        SaveObject saveObject = new SaveObject
        {
            playerPosition = playerCurrentPosition,
            score = transform.Find("ScoreText").gameObject.GetComponent<Text>().text,
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
        transform.Find("ScoreText").gameObject.GetComponent<Text>().text = loadObject.score;

        //YAPILACAK: Oyunun geri yuklendigini belirtmek icin ui eklelemesi yap
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
    };

}
