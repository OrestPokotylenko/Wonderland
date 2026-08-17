using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 100;
    [SerializeField] private int maxStamina = 100;

    public int Health { get; private set; }
    public int MaxHealth => maxHealth;

    public int Mana { get; private set; }
    public int MaxMana => maxMana;

    public int Stamina { get; private set; }
    public int MaxStamina => maxStamina;

    private void Awake()
    {
        Health = maxHealth;
        Mana = maxMana;
        Stamina = maxStamina;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(0, Health - damage);
    }

    public void LoseStamina(int amount)
    {
        Stamina = Mathf.Max(0, Stamina - amount);
    }

    public void GetStamina(int amount)
    {
        Stamina = Mathf.Min(maxStamina, Stamina + amount);
    }
}