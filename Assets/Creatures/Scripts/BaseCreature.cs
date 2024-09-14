using UnityEngine;

public abstract class BaseCreature : MonoBehaviour
{
    protected Rigidbody2D creature;
    protected int health;
    protected int damage;

    protected void Start()
    {
        creature = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DestroyCreature();
    }

    private void DestroyCreature()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}