using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 directionalInput;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {


    }

    public void SetDirectionalInput(Vector3 directionalInput)
    {
        this.directionalInput = directionalInput;

    }



    private void moveCharacter(Vector3 directionalInput)
    {
        controller.Move(directionalInput);

    }

}
