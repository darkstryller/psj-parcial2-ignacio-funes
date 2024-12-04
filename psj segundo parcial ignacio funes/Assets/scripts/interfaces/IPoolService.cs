using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolService 
{
    EnemyController callDeque(EnemyType type, Vector3 position);
}
