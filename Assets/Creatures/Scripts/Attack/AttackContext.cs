using UnityEngine;

public struct AttackContext
{
    public GameObject Attacker;
    public Vector2 Direction;
    public Vector2 Position;

    public AttackContext(
        GameObject attacker,
        Vector2 direction,
        Vector2 position)
    {
        Attacker = attacker;
        Direction = direction;
        Position = position;
    }
}