using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour, IPoolService
{
    public EnemyController ZombieController;
    public EnemyController SkeletonController;
    public EnemyType zombie;
    public EnemyType skeleton;

    private void Awake()
    {
        pool.SetupPool(ZombieController, 5, zombie);
        pool.SetupPool(SkeletonController, 3, skeleton);
    }
    public EnemyController callDeque(EnemyType type, Vector3 position)
    {
        EnemyController instance = pool.DequeObject<EnemyController>(type);
        if (instance == null)
            return null;
        instance.gameObject.SetActive(true);
        instance.transform.position = position;
        instance.initialize();

        return instance;
    }
}
