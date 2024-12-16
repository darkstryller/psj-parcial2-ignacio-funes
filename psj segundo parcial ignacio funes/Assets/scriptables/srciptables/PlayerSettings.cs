using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//scriptable del player, un flyweight
[CreateAssetMenu(fileName = "player", menuName = "scriptables/entity/player", order = 0)]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] int maxLife;
    [SerializeField] float speed;

    public float Speed => speed;
    public int MaxLife => maxLife;
}
