using UnityEngine;
using UnityEngine.InputSystem;

public class player2Dctrl : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 450;
    private Rigidbody2D rb;
    private float moveInputValue;
    private bool isGrounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        rb.linearVelocity = new Vector2(moveInputValue * speed, rb.linearVelocity.y);
        if(moveInputValue < 0) { }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
