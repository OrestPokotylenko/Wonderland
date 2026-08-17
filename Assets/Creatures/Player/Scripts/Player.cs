using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour
{
    protected PlayerStats stats;

    private SpriteRenderer spriteRenderer;
    private Material material;

    protected virtual void Awake()
    {
        stats = GetComponent<PlayerStats>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
    }

    public virtual void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
        StartCoroutine(DamageFlash());
    }

    private IEnumerator DamageFlash()
    {
        material.SetFloat("_FlashAmount", 1f);

        yield return new WaitForSeconds(0.1f);

        material.SetFloat("_FlashAmount", 0f);
    }
}