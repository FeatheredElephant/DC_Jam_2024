using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float MaxHealh { get; set; }
    float CurrentHealth { get; set; }

    void Damage(float amount);
    void Die();
}
