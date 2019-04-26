using UnityEngine;


[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    private Vector3 directionalInput;
    private Player player;


    private void Start()
    {
        player = GetComponent<Player>();
    }
    
    
    private void Update()
    {
        directionalInput = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        Flip(directionalInput);
        player.SetDirectionalInput(directionalInput);
       
    }

    //Klavye girisine gore karakterin baktigi yonun degistirilmesi
    private void Flip(Vector3 directionalInput)
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

    //Karakter ziplama ve cift ziplama kontrolu yazilacak
}
