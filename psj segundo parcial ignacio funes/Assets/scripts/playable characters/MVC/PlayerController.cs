using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerModel model;

    FSM<PlayerStateEnum> fsm;
    ITreeNode root;
   
    private void Awake()
    {
        
        initializeFSM();
        initializeTree();
    }
    

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
        root.Execute();
    }

    void initializeFSM()
    {
        fsm = new FSM<PlayerStateEnum>();
        var idle = new IdleState<PlayerStateEnum>();
        var move = new MoveState<PlayerStateEnum>(model.Move, model.Player.Speed, model.Rb);
        var dead = new DeadState<PlayerStateEnum>(model);
        idle.AddTransition(PlayerStateEnum.move, move);
        idle.AddTransition(PlayerStateEnum.dead, dead);

        move.AddTransition(PlayerStateEnum.idle, idle);
        move.AddTransition(PlayerStateEnum.dead, dead);

        dead.AddTransition(PlayerStateEnum.idle, idle);
        dead.AddTransition(PlayerStateEnum.move, move);

        fsm.SetInitial(idle);
    }

    void initializeTree()
    {
        var idle = new ActionTree(() => fsm.Transition(PlayerStateEnum.idle));
        var move = new ActionTree(() => fsm.Transition(PlayerStateEnum.move));
        var dead = new ActionTree(() => fsm.Transition(PlayerStateEnum.dead));

        var qIsMoving = new QuestionTree(QuestionIsMoving, idle, move);
        var qIsAlive = new QuestionTree(QuestionIsAlive, dead, qIsMoving);
        
        root = qIsMoving;
    }

    bool QuestionIsMoving()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        return dir != Vector2.zero;
    }
    bool QuestionIsAlive()
    {
        return model.IsAlive;
    }
}
