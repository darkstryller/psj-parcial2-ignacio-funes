using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//pool manager es una clase con accesso al pool, no es el pool
public class PoolManager : MonoBehaviour, IPoolService
{
    public EnemyController ZombieController;
    public EnemyController SkeletonController;
    public EnemyType zombie;
    public EnemyType skeleton;

    private void Awake()
    {
        pool.SetupPool(ZombieController, 2, zombie);
        pool.SetupPool(SkeletonController, 1, skeleton);
    }
    //funcion para obtener el pool
    public EnemyController callDeque(EnemyType type, Vector3 position)
    {
        EnemyController instance = pool.DequeObject<EnemyController>(type);
        if (instance == null)
            return null;
        instance.gameObject.SetActive(true);
        instance.transform.position = position;
        instance.Model.Health.SetLife(instance.Model.Settings.MaxLife);
        instance.initialize();

        return instance;
    }
}
