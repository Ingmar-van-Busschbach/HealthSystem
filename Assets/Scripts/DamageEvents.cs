using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvents : MonoBehaviour
{
    public static DamageEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<float, GameObject> onApplyDamage;
    public void ApplyDamage(float damage = 0, GameObject target = null)
    {
        onApplyDamage?.Invoke(damage, target);
    }
}
