using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{

    private Transform groundCheck;
    private Transform ceilingCheck;

    private Rigidbody2D rb;
    private Vector2 directionalInput;
    private Vector2 playerMovementVector;
    private Collider2D colliders;

    private float playerHorizontalMovement;
    private float playerVerticalMovement = 0;
    private float playerMovementSpeed = 120f;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private float groundedRadius = .2f;
    private float jumpForce  = 400f;

    [SerializeField]
    private bool isAirControl = false;
    [SerializeField]
    private LayerMask whatIsGround;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        
    }

    //fizik hesaplamalarinin yapilmasi
    void  FixedUpdate()
    {
        isGrounded = false;

        CheckGround();

        playerHorizontalMovement = directionalInput.x * Time.fixedDeltaTime * playerMovementSpeed;

        MoveCharacterHorizontal(new Vector2(playerHorizontalMovement, rb.velocity.y));
    }


    //Karakterin yatay olarak hareket ettirilmesi
    private void MoveCharacterHorizontal(Vector2 playerHorizontalMovement)
    {
        if (isGrounded || isAirControl)
        {
            rb.velocity = playerHorizontalMovement;

        }

    }
    //Ziplama ve cift ziplama
    public void MoveCharacterVertical()
    {

        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));

        }

        if (!isGrounded && canDoubleJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canDoubleJump = false;
        }


    }

    
    public float PlayerMovementSpeed
    {
        set
        {
            if(value > 50 && value < 120)
            {
                playerMovementSpeed = value;
            }
        }
    }

    //oyuncudan gelen girisin set edilmesi
    public void SetDirectionalInput(Vector2 directionalInput)
    {
        this.directionalInput = directionalInput;

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
