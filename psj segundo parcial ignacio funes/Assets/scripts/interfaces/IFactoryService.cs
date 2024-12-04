using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryService 
{
    GameObject CreateEnemy(EnemyType type, Vector3 spawnPosition);
}
