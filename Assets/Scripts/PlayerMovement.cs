using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    
    public float jumpForce;

    public Rigidbody2D playerRigidBody;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;

    private bool isJumping;
    
    [HideInInspector]
    public bool isClimbing;

    public Animator animator;

    public SpriteRenderer sprRenderer;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    private float horizontalMovement;
    private float verticalMovement;
    public int nbJump;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are more than one PlayerMovement instance in the scene");
            return;
        }

        instance = this;
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalMovement, verticalMovement);
        DetectGroundCollision();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DoubleJump();
        }
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;
        
        Flip(playerRigidBody.velocity.x);
        
        float characterVelocity = Mathf.Abs(playerRigidBody.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
        if (isClimbing && verticalMovement != 0) 
        {
            animator.SetBool("IsClimbing", true);
        }
        else
        {
            animator.SetBool("IsClimbing", false);
        }

    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRigidBody.velocity.y);
        playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity, targetVelocity, ref velocity, 0.01f);
        

        if (isJumping)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0);
            playerRigidBody.AddForce(new Vector2(0f, jumpForce + ((nbJump+1) * 50)));
            isJumping = false;
        }

        if (isClimbing)
        {
            Vector3 targetVelocityY = new Vector2(playerRigidBody.velocity.x, _verticalMovement);
            playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity, targetVelocityY, ref velocity, 0.05f);
            
        }

    }

    void DetectGroundCollision()
    {
        bool isgrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, collisionLayers);
        if (isgrounded && isJumping == false)
        {
            ResetDoubleJump();
        }
    }

    void ResetDoubleJump()
    {
        this.nbJump = 2;
    }

    void DoubleJump()
    {
        if (this.nbJump > 0)
        {
            this.nbJump--;
            this.isJumping = true;
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            sprRenderer.flipX = false;
        }

        else if (velocity < - 0.1f)
        {
            sprRenderer.flipX = true;

        }
    }

    public float GetVerticalMovement()
    {
        return verticalMovement;
    }
        
}
