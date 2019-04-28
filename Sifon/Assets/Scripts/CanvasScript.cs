using UnityEngine;

public class CanvasScript : MonoBehaviour
{

    private PlayerInput playerInput;
    private Transform menuPanel;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        menuPanel = transform.Find("MenuPanel");
        menuPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
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




    public void ExitGame()
    {

        Application.Quit();
  
    }

}
