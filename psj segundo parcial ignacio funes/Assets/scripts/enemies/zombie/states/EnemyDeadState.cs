using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState<T> : State<T>
{
    EnemyModel model;

    public EnemyDeadState(EnemyModel model)
    {
        this.model = model;
    }

    public override void Enter()
    {
        base.Enter();
        model.die();
    }
}
