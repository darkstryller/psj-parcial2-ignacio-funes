using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContainer : MonoBehaviour, IMove
{
    public void move(Vector2 dir, float speed, Rigidbody2D body)
    {
        body.velocity += dir * speed * Time.deltaTime;
       
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
