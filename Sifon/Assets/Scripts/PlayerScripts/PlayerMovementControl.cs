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
    private PlayerInput playerInput;
    
    private Rigidbody2D rb;
    private Vector2 playerMovementVector;
    private Collider2D colliders;

    private float playerHorizontalMovement;
    private float playerMovementSpeed = 100f;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private const float groundedRadius = .2f;
    private const float jumpForce  = 400f;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");           
    }

    //fizik hesaplamalarinin yapilmasi
    void  FixedUpdate()
    {
        isGrounded = false;
        CheckGround();
        MoveCharacter();
    }

    //Karakterin hareket ettirilmesi
    private void MoveCharacter()
    {
        playerHorizontalMovement = playerInput.DirectionalInput.x * Time.fixedDeltaTime * playerMovementSpeed;
        //eger karakter yere temas ediyorsa veya havada kontrol aktif ise saga-sola hareket edilebilmesi
        if (isGrounded || isAirControl)
        {
            rb.velocity = new Vector2(playerHorizontalMovement, rb.velocity.y);
        }
        if (isGrounded && playerInput.JumpButtonDown())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            canDoubleJump = true;
            isGrounded = false;
        }
        else if (!isGrounded && canDoubleJump && playerInput.JumpButtonDown())
        {
            canDoubleJump = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
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
            }
        }
    }
}
