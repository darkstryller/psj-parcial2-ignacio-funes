using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player", menuName = "scriptables/entity/player", order = 0)]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int maxLife;
    [SerializeField] float speed;

    public float Speed => speed;
    public int MaxLife => maxLife;
    public string Name => name;
}
