using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedPlayerHealth : HealthSystem
{
    [SerializeField] private Image _healthBarCore;
    [SerializeField] private Gradient damagedGradient;
    private float _currentHealth;
    private float _startHealth;
    protected override void BeginPlay()
    {
        _currentHealth = _health;
        _startHealth = _health;
    }
    protected override void OnDamaged(float damage)
    {
        _health -= damage;
        //Debug.Log("Player Takes " + damage + " Damage");
        //Debug.Log("Player Has " + _targetHealth + " Health Left");
        StartCoroutine(AnimateDamage());
    }
    protected override void OnDeath()
    {
        StartCoroutine(AnimateDamage());
        GameEvents.current.PlayerGameOver();
    }

    IEnumerator AnimateDamage()
    {
        var currentHealth = _currentHealth;
        //Debug.Log(currentHealth);
        //Debug.Log(_targetHealth);
        var t = 0.0f;
        while (_currentHealth != _health)
        {
            _currentHealth = Mathf.Lerp(currentHealth, _health, t);
            Debug.Log(_currentHealth);
            var healthBarTransform = _healthBarCore.transform as RectTransform;
            healthBarTransform.sizeDelta = new Vector2(_currentHealth * 100/_startHealth, healthBarTransform.sizeDelta.y);
            _healthBarCore.color = damagedGradient.Evaluate(t);
            t += 0.25f;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
