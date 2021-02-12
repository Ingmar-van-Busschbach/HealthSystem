using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] protected float _damage = 10.0f;

    protected virtual void ApplyDamage(float damage, GameObject target)
    {
        DamageEvents.current.ApplyDamage(damage, target);
    }
}
