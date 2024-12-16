using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyModel model;
    [SerializeField] GameObject targetprefab;
    [SerializeField] bool debugboolmove;

    FSM<EnemyStateEnum> fsm;
    ITreeNode root;
    private void Awake()
    {
        initialize();
    }
    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
        root.Execute();
        
    }
    public void initialize()
    {
        initializeFSM();
        initializeTree();
    }
    void initializeFSM()
    {
        fsm = new FSM<EnemyStateEnum>();

        var idle = new EnemyIdleState<EnemyStateEnum>();
        var move = new EnemyMovestate<EnemyStateEnum>(model.Move, model, targetprefab);
        var dead = new EnemyDeadState<EnemyStateEnum>(model);

        idle.AddTransition(EnemyStateEnum.move, move);
        idle.AddTransition(EnemyStateEnum.dead, dead);

        move.AddTransition(EnemyStateEnum.idle, idle);
        move.AddTransition(EnemyStateEnum.dead, dead);

        dead.AddTransition(EnemyStateEnum.idle, idle);
        dead.AddTransition(EnemyStateEnum.move, move);

        fsm.SetInitial(idle);
    }
    void initializeTree()
    {
        var idle = new ActionTree(() => fsm.Transition(EnemyStateEnum.idle));
        var move = new ActionTree(() => fsm.Transition(EnemyStateEnum.move));
        var dead = new ActionTree(() => fsm.Transition(EnemyStateEnum.dead));

        var qIsMoving = new QuestionTree(QuestionIsMoving, move, idle);
        var qIsAlive = new QuestionTree(QuestionIsAlive, dead, qIsMoving);

        root = qIsAlive;
    }

    bool QuestionIsMoving()
    {
        return debugboolmove;
    }
    bool QuestionIsAlive()
    {
        return model.IsAlive;
    }

    public EnemyModel Model => model;
}
