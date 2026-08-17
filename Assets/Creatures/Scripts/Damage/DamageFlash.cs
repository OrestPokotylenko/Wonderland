using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteRenderer))]
public class DamageFlash : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] Color _flashColor = Color.white;
    [SerializeField] float _flashDuration = 0.25f;
    [SerializeField] private AnimationCurve _flashSpeedCurve;
    private SpriteRenderer _spriteRenderer;
    private Material _material;

    private Health _health;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Damaged += OnDamaged;
    }

    private void OnDamaged(int damage)
    {
        StartCoroutine(SetDamageFlash());
    }

    private void OnDisable()
    {
        _health.Damaged -= OnDamaged;
    }

    private IEnumerator SetDamageFlash()
    {
        _material.SetColor("_FlashColor", _flashColor);
        float elapsedTime = 0f;

        while (elapsedTime < _flashDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentFlashAmount = Mathf.Lerp(1f, _flashSpeedCurve.Evaluate(elapsedTime), elapsedTime / _flashDuration);
            _material.SetFloat("_FlashAmount", currentFlashAmount);

            yield return null;
        }
    }
}
