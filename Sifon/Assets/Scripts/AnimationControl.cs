using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private PlayerMovementControl playerMovement;
    private PlayerInput playerInput;
    private GameObject firePoint;
    private Vector2 directionalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    void Update()
    {
        Flip(playerInput.DirectionalInput);
    }

    //Klavye girisine gore karakterin baktigi yonun degistirilmesi
    private void Flip(Vector2 directionalInput)
    {
        firePoint = playerMovement.transform.Find("FirePoint").gameObject;

        if (directionalInput.x > 0)
        {
            playerMovement.GetComponent<SpriteRenderer>().flipX = false;
            firePoint.transform.rotation = Quaternion.Euler(0, 0, 0);
            firePoint.transform.position = new Vector3(playerMovement.transform.position.x + .25f, playerMovement.transform.position.y, playerMovement.transform.position.z);


        }
        if (directionalInput.x < 0)
        {
            playerMovement.GetComponent<SpriteRenderer>().flipX = true;
            firePoint.transform.rotation = Quaternion.Euler(0, -180, 0);
            firePoint.transform.position = new Vector3(playerMovement.transform.position.x - .25f, playerMovement.transform.position.y, playerMovement.transform.position.z);
        }
    }
}
