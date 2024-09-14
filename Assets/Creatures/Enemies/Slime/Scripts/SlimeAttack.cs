using UnityEngine;

public class SlimeAttack : Slime
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<BaseCreature>().TakeDamage(damage);
        }
    }
}