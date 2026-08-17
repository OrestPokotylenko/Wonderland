using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float pushBackForce = 3f;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Move();

        rb.linearVelocity = movement;

        UpdateAnimation(movement);
    }

    private Vector2 Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new(moveHorizontal, moveVertical);

        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }

        return movement * speed;
    }

    private void UpdateAnimation(Vector2 movement)
    {
        animator.SetFloat("Speed", movement.magnitude);

        if (movement.sqrMagnitude > 0.01f)
        {
            Vector2 direction = movement.normalized;

            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NotStepableObject"))
        {
            Vector2 pushDirection =
                (rb.position - (Vector2)collision.transform.position).normalized;

            rb.AddForce(
                pushDirection * pushBackForce,
                ForceMode2D.Impulse
            );
        }
    }
}