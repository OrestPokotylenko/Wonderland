using UnityEngine;

public class PlayerBehaviour : Player
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float pushBackForce;

    void FixedUpdate()
    {
        creature.velocity = Move();
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
            Vector2 pushDirection = (creature.position - (Vector2)collision.transform.position).normalized;
            creature.AddForce(pushDirection * pushBackForce, ForceMode2D.Impulse);
        }
    }
}