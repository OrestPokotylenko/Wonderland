using UnityEngine;

public class IdleBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D _idle;

    private void Start()
    {
        _idle = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _idle.velocity = Move();
    }

    private Vector2 Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        return movement * movementSpeed;
    }
}