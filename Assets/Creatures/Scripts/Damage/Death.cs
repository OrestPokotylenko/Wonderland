using UnityEngine;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    private Health _health;
    private RespawnManager _respawnManager;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _respawnManager = FindAnyObjectByType<RespawnManager>();
    }

    private void OnEnable()
    {
        _health.Died += OnDeath;
    }

    private void OnDeath()
    {
        _respawnManager.Respawn();
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        _health.Died -= OnDeath;
    }
}