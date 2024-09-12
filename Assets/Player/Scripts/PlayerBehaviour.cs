using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
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
}