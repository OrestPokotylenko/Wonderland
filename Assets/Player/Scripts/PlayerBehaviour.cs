using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float pushBackForce;
    private Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        player.velocity = Move();
    }

    private Vector2 Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new(moveHorizontal, moveVertical);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        return movement * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NotStepableObject"))
        {
            Vector2 pushDirection = (player.position - (Vector2)collision.transform.position).normalized;
            player.AddForce(pushDirection * pushBackForce, ForceMode2D.Impulse);
        }
    }
}