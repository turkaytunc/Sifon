using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMovementControl : MonoBehaviour
{
    [SerializeField]private bool isAirControl = false;
    [SerializeField]private LayerMask whatIsGround;

    private Transform groundCheck;
    private PlayerInput playerInput;
    private Rigidbody2D rb;

    private float playerHorizontalMovement;
    private float playerMovementSpeed = 100f;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private const float groundedRadius = .1f;
    private const float jumpForce = 180f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }
    //fizik hesaplamalarinin yapilmasi
    void FixedUpdate()
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

        if (isGrounded && playerInput.JumpButtonDown)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime *100));
            canDoubleJump = true;
            playerInput.JumpButtonDown = false;
        }
        else if (!isGrounded && canDoubleJump && playerInput.JumpButtonDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime *100));
            canDoubleJump = false;
            playerInput.JumpButtonDown = false;
        }
    }
    //karakterin harektet hizinin belli bir aralikta tutulmasi
    public float PlayerMovementSpeed
    {
        set
        {
            if (value > 100 && value < 200)
            {
                playerMovementSpeed = value;
            }
        }
    }

    //karakterin carpisma dedektoru kullanarak yakin oldugu yuzeyin yer olup olmadigini kontrol etmesi
    private void CheckGround()
    {
        RaycastHit2D r2d = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, whatIsGround);

        if (r2d)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("Scene001");
        }
    }
}
