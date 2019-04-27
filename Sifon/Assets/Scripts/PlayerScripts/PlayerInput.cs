using UnityEngine;


[RequireComponent(typeof(PlayerMovementControl))]
public class PlayerInput : MonoBehaviour
{

    private Vector2 directionalInput;
    private PlayerMovementControl player;
   


    private void Start()
    {
        player = GetComponent<PlayerMovementControl>();       

    }

    
    
    private void Update()
    {
        
        directionalInput = new Vector2 (Input.GetAxisRaw("Horizontal"), 0);

        player.SetDirectionalInput(directionalInput);
        JumpInput();
        Flip(directionalInput);

        

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

    
    private void JumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.MoveCharacterVertical();
        }

    }
}
