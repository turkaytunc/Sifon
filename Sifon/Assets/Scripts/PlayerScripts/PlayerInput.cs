using UnityEngine;

[RequireComponent(typeof(PlayerMovementControl))]
public class PlayerInput : MonoBehaviour
{

    public Vector2 DirectionalInput { get; set; }
    private PlayerMovementControl player;

    private void Start()
    {
        player = GetComponent<PlayerMovementControl>();
    }

    private void Update()
    { 
        DirectionalInput = new Vector2 (Input.GetAxisRaw("Horizontal"), 0);
        JumpButtonDown();

        Flip(DirectionalInput);
    }

    //Klavye girisine gore karakterin baktigi yonun degistirilmesi
    private void Flip(Vector2 directionalInput)
    {
        if(directionalInput.x > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(directionalInput.x < 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public bool EscapeButtonDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }
        return false;    
    }
    
    public bool JumpButtonDown()
    {
        if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        return false;
    }
}
