using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float _health = 100.0f;
    void Start()
    {
        DamageEvents.current.onApplyDamage += ApplyDamage;
        BeginPlay();
    }

    private void ApplyDamage(float damage = 0, GameObject target = null)
    {
        if (target != this.gameObject) { return; // Ignore damage if target is not this gameObject
        }
        OnDamaged(damage);
        if (_health <= 0){
            OnDeath();
        }
    }
    protected virtual void BeginPlay(){}// Use this function instead of start with childs to prevent overriding Start()
    protected virtual void OnDamaged(float damage){}
    protected virtual void OnDeath(){}
}
