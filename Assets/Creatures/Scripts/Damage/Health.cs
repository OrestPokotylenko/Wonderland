using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxHealth = 100;
    
    public int CurrentHealth { get; private set; }

    public event Action<int> Damaged;
    public event Action Died;

    public void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);

        Damaged?.Invoke(damage);

        if (CurrentHealth == 0)
        {
            Died?.Invoke();
        }
    }
}