using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isMoving;
    private bool facingRight = true; // Indicates whether the player is facing right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float moveVelocity = moveInput * speed;
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        // Check if the player is moving
        isMoving = Mathf.Abs(moveVelocity) > 0.1f;

        // Set the "isMoving" parameter in the Animator Controller
        animator.SetBool("isMoving", isMoving);

        // Flip the sprite if the direction of movement changes
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight; // Toggle the facingRight variable

        // Flip the player's sprite horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
