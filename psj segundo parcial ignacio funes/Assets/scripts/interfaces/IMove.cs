using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
   void move(Vector2 dir, float speed, Rigidbody2D body);
}
