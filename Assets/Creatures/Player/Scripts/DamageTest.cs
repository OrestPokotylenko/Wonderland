using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamageTest : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float interval = 2f;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(DealDamage), interval, interval);
    }

    private void DealDamage()
    {
        health.TakeDamage(damage);
    }
}