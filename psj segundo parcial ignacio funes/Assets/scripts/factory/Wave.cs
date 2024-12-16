using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "wave", menuName= "scriptables/wave")]
public class Wave : ScriptableObject
{
    public EnemyType[] Enemies;
    public Vector3[] Positions;
    
    //primero localiza los servicios con service locator, despues los utiliza
    public void SpawnWave()
    {
        GameObject enemy = null;
        EnemyController controller = null;
        var factory = ServiceLocator.Instance.GetService<IFactoryService>();
        var pool = ServiceLocator.Instance.GetService<IPoolService>();
        //primero busca en el pool, si el pool esta vacio, utiliza factory
        if (Enemies.Length == Positions.Length)
            for (int i = 0; i < Enemies.Length; i++)
            {
                controller = pool.callDeque(Enemies[i], Positions[i]);
                
                if(controller == null)
                 enemy = factory.CreateEnemy(Enemies[i], Positions[i]);
            }
    }

}
