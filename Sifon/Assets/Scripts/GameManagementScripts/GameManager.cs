using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

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

}
