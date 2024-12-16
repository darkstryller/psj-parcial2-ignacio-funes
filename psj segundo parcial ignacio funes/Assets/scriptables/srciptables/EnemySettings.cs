using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//scriptable del enemigo, un flyweight
[CreateAssetMenu(fileName = "EnemyType", menuName = "scriptables/entity/EnemyType", order =1)]
public class EnemySettings : ScriptableObject
{
    [SerializeField] int maxlife;
    [SerializeField] float speed;

    public int  MaxLife => maxlife;
    public float Speed => speed;
}
