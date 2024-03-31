using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour, ICuttable, IDamageable
{
    [field: SerializeField] public Vector3 playerPosition;
    [field: SerializeField] public float MaxHealth { get; set; } = 0;
    [field: SerializeField] public float CurrentHealth { get; set; } = 0;

    public void Cut(Vector3 position)
    {
        Die();
    }

    public void Damage(float amount)
    {
        //Damage animation
        //Knockback
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
