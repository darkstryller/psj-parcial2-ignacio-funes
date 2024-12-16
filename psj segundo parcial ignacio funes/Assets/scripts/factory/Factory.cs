using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Factory : MonoBehaviour, IFactoryService
{
    //se agrega desde editor los parametros de las keys y de los objetos
    public GameObject ZombiePrefab;   
    public GameObject SkeletonPrefab; 
    public EnemySettings ZombieSettings; 
    public EnemySettings SkeletonSettings;
    
    void Awake()
    {
        
    }
    
    public GameObject CreateEnemy(EnemyType type, Vector3 spawnPosition)
    {
        GameObject prefabToSpawn = GetPrefab(type);
        GameObject enemyInstance = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Initialize all components
        InitializeComponents(enemyInstance, type);

        return enemyInstance;
    }

    GameObject GetPrefab(EnemyType type)
    {
        //me gusta el switch
        switch (type)
        {
            case EnemyType.Zombie:
                return ZombiePrefab;
            case EnemyType.Skeleton:
                return SkeletonPrefab;
            default:
                throw new System.ArgumentException("Invalid EnemyType type");
        }
    }

    void InitializeComponents(GameObject enemy, EnemyType type)
    {
        // Get components
        EnemyController controller = enemy.GetComponent<EnemyController>();
        EnemyModel model = enemy.GetComponent<EnemyModel>();
        MoveContainer moveContainer = enemy.GetComponent<MoveContainer>();
        HealthContainer healthContainer = enemy.GetComponent<HealthContainer>();

        // se asegura de agregar el scriptable
        switch (type)
        {
            case EnemyType.Zombie:
                model.Settings = ZombieSettings;
                break;
            case EnemyType.Skeleton:
                model.Settings = SkeletonSettings;
                break;
        }

        pool.poolDictionary[type].Enqueue(controller);
    }

   
    

}
