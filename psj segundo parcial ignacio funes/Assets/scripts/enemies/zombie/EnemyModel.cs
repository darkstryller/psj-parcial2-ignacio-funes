using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public EnemySettings Settings;
    [SerializeField] Rigidbody2D body;
    [SerializeField] int currentlife;
    [SerializeField] MoveContainer moveContainer;
    [SerializeField] EnemyType type;
    [SerializeField] EnemyController controller;

    HealthContainer health;

    void Awake()
    {
        health.SetLife(Settings.MaxLife);
    }
    public void die()
    {
        pool.EnqueObject(controller, type);

    }
    public Vector2 SetDir(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        dir = dir.normalized;
        return dir;
    }

    public Rigidbody2D Body => body;
    public MoveContainer Move => moveContainer;
    public bool IsAlive => currentlife <= 0;
}
