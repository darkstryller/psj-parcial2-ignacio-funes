using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    //strategy
    [SerializeField] int damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.GetDamage(damage);
        }
    }
}
