using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;

    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * moveSpeed);
        }

        if (Mathf.Abs(rb.linearVelocityX) > maxSpeed)
        {
            rb.linearVelocity = new Vector2(maxSpeed * Mathf.Clamp(rb.linearVelocityX, -1, 1), rb.linearVelocity.y);
        }

        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
