using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovestate<T> : State<T>
{
    MoveContainer move;
    EnemyModel model;
    Vector2 dir;
    GameObject target;

    public EnemyMovestate(MoveContainer move, EnemyModel model, GameObject target)
    {
        this.move = move;
        this.model = model;
        this.target = target;
    }

    public override void Execute()
    {
        base.Execute();
         dir = model.SetDir(target.transform);
         
        move.move(dir.normalized, model.Settings.Speed, model.Body);
    }
    public override void Enter()
    {
        base.Enter();
        dir = Vector2.zero;
    }
}
