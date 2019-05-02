using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMovementControl : MonoBehaviour
{
    [SerializeField]
    private bool isAirControl = false;
    [SerializeField]
    private LayerMask whatIsGround;

    private Transform groundCheck;
    private Transform ceilingCheck;
    private PlayerInput playerInput;
    
    private Rigidbody2D rb;
    private Vector2 directionalInput;
    private Vector2 playerMovementVector;
    private Collider2D colliders;
    private CameraFollow cameraFollow;

    private float playerHorizontalMovement;
    private float playerMovementSpeed = 100f;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private const float groundedRadius = .01f;
    private const float jumpForce  = 400f;

    void Start()
    {
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");      
    }

    //fizik hesaplamalarinin yapilmasi
    void  FixedUpdate()
    {
        directionalInput = playerInput.DirectionalInput;
        cameraFollow.CameraFollowPosition = transform.position;
        isGrounded = false;
        CheckGround();
        MoveCharacter();
        
    }

    //Karakterin yatay olarak hareket ettirilmesi
    private void MoveCharacter()
    {
        playerHorizontalMovement = directionalInput.x * Time.fixedDeltaTime * playerMovementSpeed;
        //eger karakter yere temas ediyorsa veya havada kontrol aktif ise saga-sola hareket edilebilmesi
        if (isGrounded || isAirControl)
        {
            rb.velocity = new Vector2(playerHorizontalMovement, rb.velocity.y);
        }
        if (isGrounded && playerInput.JumpButtonDown())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        if (!isGrounded && canDoubleJump && playerInput.JumpButtonDown())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canDoubleJump = false;
        }
    }

    //karakterin harektet hizinin belli bir aralikta tutulmasi
    public float PlayerMovementSpeed
    {
        set
        {
            if(value > 100 && value < 200)
            {
                playerMovementSpeed = value;
            }
        }
    }

    //karakterin carpisma dedektoru kullanarak yakin oldugu yuzeyin yer olup olmadigini kontrol etmesi
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                
                isGrounded = true;
                canDoubleJump = true;
            }
        }
    }




}
