using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //Oyunda tek bir tane GameMaster objesi olmasinin garanti altina alinmasi
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


    private void Update()
    {
        //oyunu resetleme
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Scene001");
        }
    }
}
