using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "wave", menuName= "scriptables/wave")]
public class Wave : ScriptableObject
{
    public EnemyType[] Enemies;
    public Vector3[] Positions;
    public Factory Factory;

    public void SpawnWave()
    {
        if(Enemies.Length == Positions.Length)
        for (int i = 0; i < Enemies.Length; i++) 
        {
           Factory.CreateEnemy(Enemies[i], Positions[i]);
        }
    }
}
