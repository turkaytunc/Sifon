using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private PlayerMovementControl playerMovement;
    private PlayerInput playerInput;
    private Animator anim;
    private FirePoint firePoint;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControl>();
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        firePoint = GameObject.FindGameObjectWithTag("Player").GetComponent<FirePoint>();
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
        if (directionalInput.x > 0)
        {
            playerMovement.transform.localScale = new Vector3(1f, 1f, 1f);
            firePoint.FaceRight = true;
        }
        if (directionalInput.x < 0)
        {
            playerMovement.transform.localScale = new Vector3(-1f, 1f, 1f);
            firePoint.FaceRight = false;
        }
    }

    private void NullCheck()
    {
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControl>();
        }
        if (playerInput == null)
        {
            playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        }
        if (anim == null)
        {
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }
        if (firePoint == null)
        {
            firePoint = GameObject.FindGameObjectWithTag("Player").GetComponent<FirePoint>();
        }
    }
}
