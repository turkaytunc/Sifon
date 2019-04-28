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

        if (playerInput.KeyboardInputEscape())
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

    public void SaveGameButton()
    {
        SaveObject saveObject = new SaveObject
        {
            playerPosition = playerCurrentPosition,
            score = transform.Find("ScoreText").gameObject.GetComponent<Text>().text,
        };

        json = JsonUtility.ToJson(saveObject);

        Debug.Log(saveObject.score);

        SaveLoadHandler.SaveGame(json);
    }

    public void LoadGameButton()
    {
        loadedString = SaveLoadHandler.LoadGame();

        SaveObject loadObject = JsonUtility.FromJson<SaveObject>(loadedString);

        movementControl.transform.position = loadObject.playerPosition;
        transform.Find("ScoreText").gameObject.GetComponent<Text>().text = loadObject.score;
    }




    public void ExitGameButton()
    {

        Application.Quit();
  
    }



    public class SaveObject
    {
        public Vector3 playerPosition;
        public string score;
    };

}
