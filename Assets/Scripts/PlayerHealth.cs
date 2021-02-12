using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    [SerializeField] private Text text;
    protected override void BeginPlay()
    {
        text.text = "Health: " + _health;
    }
    protected override void OnDamaged(float damage)
    {
        _health -= damage;
        text.text = "Health: " + _health;
    }
    protected override void OnDeath()
    {
        Debug.Log("Player died");
    }
}
