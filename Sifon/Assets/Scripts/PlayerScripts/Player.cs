using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 directionalInput;
    private Vector3 playerMovementVector;
    private float playerHorizontalMovement;

    private float playMovementSpeed = 2f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    //fizik hesaplamalarinin yapilmasi
    void  FixedUpdate()
    {
        playerHorizontalMovement = directionalInput.x * Time.fixedDeltaTime * playMovementSpeed;

        playerMovementVector = new Vector3(playerHorizontalMovement, 0, 0);
        
        MoveCharacterHorizontal(playerMovementVector);
    }

    //oyuncudan gelen girisin set edilmesi
    public void SetDirectionalInput(Vector3 directionalInput)
    {
        this.directionalInput = directionalInput;

    }

    //Karakterin yatay olarak hareket ettirilmesi
    private void MoveCharacterHorizontal(Vector3 directionalInput)
    {
        controller.Move(directionalInput);

    }


    public float PlayerMovementSpeed
    {
        set
        {
            if(value > 0 && value < 6)
            {
                playMovementSpeed = value;
            }

        }
    }

}
