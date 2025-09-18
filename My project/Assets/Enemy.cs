using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    private float walkDuration;
    [SerializeField] private float maxWalkDuration;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float maxWalkSpeed;
    private bool goingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkDuration <= maxWalkDuration)
        {
            if (goingRight)
            {
                rb.AddForce(Vector2.right * walkSpeed);   
            }
            else
            {
                rb.AddForce(-Vector2.right * walkSpeed);
            }
        }
        else
        {
            goingRight = !goingRight;
            walkDuration = 0;
        }

        if (Mathf.Abs(rb.linearVelocityX) > maxWalkSpeed)
        {
            rb.linearVelocity = new Vector2(maxWalkSpeed * Mathf.Clamp(rb.linearVelocityX, -1, 1), rb.linearVelocity.y);
        }

        walkDuration += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GameOver();
        }
    }
}
