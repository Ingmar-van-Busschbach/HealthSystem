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
    } //Single target damage event

    public void ApplyRadialDamage(Vector3 location, float damage = 0, float range = 0, bool falloff = false)
    {
        RaycastHit[] hits = null;
        hits = Physics.SphereCastAll(location, range, Vector3.up, 0f);
        //Debug.Log(hits);
        if (hits != null)
        {
            foreach(RaycastHit hit in hits)
            {
                onApplyDamage?.Invoke(damage, hit.transform.gameObject);
            }
        }
    } //Radial damage event which calls ApplyDamage on all hit objects
}
