using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour, IDamageable
{
    [SerializeField] IDamageable impl;
    public int MyHealth;
    public virtual void GetDamage(int damage)
    {
        MyHealth -= damage;
    }

    public virtual void SetLife(int maxlife)
    {
        MyHealth = maxlife;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
