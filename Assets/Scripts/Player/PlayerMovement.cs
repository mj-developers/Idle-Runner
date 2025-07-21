using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public float jumpForce = 5f;
    public LayerMask groundLayer; // <- define la capa del suelo en el inspector
    public float groundCheckDistance = 0.47f;

    private Rigidbody2D rb2d;
    private Animator animator;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    { 

        if (CheckJumpInput() && IsGrounded())
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetBool("jumping", !IsGrounded());
    }

    bool CheckJumpInput()
    {
        return Keyboard.current.spaceKey.wasPressedThisFrame ||
               Keyboard.current.upArrowKey.wasPressedThisFrame ||
               Mouse.current.leftButton.wasPressedThisFrame;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
