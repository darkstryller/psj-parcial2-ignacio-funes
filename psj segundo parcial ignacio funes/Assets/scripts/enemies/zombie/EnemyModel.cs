using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour, IDamageable
{
    public EnemySettings Settings;
    [SerializeField] Rigidbody2D body;
    [SerializeField] int currentlife;
    [SerializeField] MoveContainer moveContainer;

    void Awake()
    {
        SetLife();
    }
    public void die()
    {
        Destroy(this.gameObject);
    }
    public Vector2 SetDir(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        dir = dir.normalized;
        return dir;
    }

    public void GetDamage(int damage)
    {
        currentlife -= damage;
    }

    public void SetLife()
    {
        currentlife = Settings.MaxLife;
    }


    public Rigidbody2D Body => body;
    public MoveContainer Move => moveContainer;
    public bool IsAlive => currentlife <= 0;
}
