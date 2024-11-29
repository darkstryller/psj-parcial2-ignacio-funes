using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState<T> : State<T>
{
    PlayerModel model;

    public DeadState(PlayerModel model)
    {
        this.model = model;
    }

    public override void Enter()
    {
        base.Enter();
        model.die();
    }
    public override void Execute()
    {
        model.die();
    }
}
