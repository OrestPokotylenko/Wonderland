using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : Player
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Creature"))
        {
            Damage(collision.gameObject);
        }
    }

    private void Damage(GameObject creature)
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Attacking " + creature.name);
            creature.GetComponent<BaseCreature>().TakeDamage(damage);
        }
    }
}