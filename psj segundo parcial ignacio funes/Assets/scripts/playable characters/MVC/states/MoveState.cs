using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : State<T>
{
    MoveContainer move;
    Vector2 dir;
    float speed;
    Rigidbody2D body;
    public MoveState(MoveContainer move, float speed, Rigidbody2D body)
    {
        this.move = move;
        
        this.speed = speed;
        this.body = body;
    }
   public override void Execute()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        dir = new Vector2(x, y);
        dir *= 100;
        move.move(dir, speed, body);
    }

    public override void Exit()
    {
        move.move(new Vector2(0, 0), 0, body);
    }
}
