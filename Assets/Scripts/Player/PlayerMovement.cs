using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float jumpForce = 5f;

    void Update()
    {
        if (CheckJumpInput())
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool CheckJumpInput()
    {
        return Keyboard.current.spaceKey.wasPressedThisFrame ||
               Keyboard.current.upArrowKey.wasPressedThisFrame ||
               Mouse.current.leftButton.wasPressedThisFrame;
    }
}
