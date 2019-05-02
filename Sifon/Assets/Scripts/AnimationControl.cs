using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private PlayerMovementControl playerMovement;
    private PlayerInput playerInput;
    private GameObject bulletPoint;
    private Vector2 directionalInput;
    private Animator anim;
    private FirePoint firePoint;


    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
        firePoint = GameObject.Find("Player").GetComponent<FirePoint>();
    }

    void Update()
    {
        NullCheck();        
        Flip(playerInput.DirectionalInput);
        ObjAnimation();
    }

    //Durma kosma animasyonu

    private void ObjAnimation()
    {
        if(playerInput.DirectionalInput.x > 0 || playerInput.DirectionalInput.x < 0)
        {
            anim.SetFloat("DurmaKosma", 1f);
        }
        if (playerInput.DirectionalInput.x == 0)
        {
            anim.SetFloat("DurmaKosma", 0f);
        }
    }

    //Klavye girisine gore karakterin baktigi yonun degistirilmesi
    private void Flip(Vector2 directionalInput)
    {
        bulletPoint = playerMovement.transform.Find("FirePoint").gameObject;

        if (directionalInput.x > 0)
        {
            playerMovement.transform.localScale = new Vector3(1f, 1f, 1f);
            firePoint.FaceRight = true;
            bulletPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
            bulletPoint.transform.position = new Vector3(playerMovement.transform.position.x + .25f, playerMovement.transform.position.y, playerMovement.transform.position.z);


        }
        if (directionalInput.x < 0)
        {
            playerMovement.transform.localScale = new Vector3(-1f, 1f, 1f);
            firePoint.FaceRight = false;
            bulletPoint.transform.rotation = Quaternion.Euler(0, -180, 0);
            bulletPoint.transform.position = new Vector3(playerMovement.transform.position.x - .25f, playerMovement.transform.position.y, playerMovement.transform.position.z);
        }
    }

    private void NullCheck()
    {
        if (playerMovement == null)
        {
          
            playerMovement = GameObject.Find("Player").GetComponent<PlayerMovementControl>();
        }

        if (playerInput == null)
        {
            playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        }

        if (anim == null)
        {
            anim = GameObject.Find("Player").GetComponent<Animator>();
        }

        if (firePoint == null)
        {
            firePoint = GameObject.Find("Player").GetComponent<FirePoint>();
        }
        
    }
}
