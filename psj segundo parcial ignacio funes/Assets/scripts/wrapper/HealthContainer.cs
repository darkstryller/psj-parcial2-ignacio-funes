using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour, IDamageable
{
    [SerializeField] IDamageable impl;
    public int MyHealth;
    public bool IsInvicible = false;
    public virtual void GetDamage(int damage)
    {
        if(IsInvicible == false)
        MyHealth -= damage;
    }

    public virtual void SetLife(int maxlife)
    {
        MyHealth = maxlife;
    }


}
