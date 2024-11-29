using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Factory : MonoBehaviour
{
    public GameObject ZombiePrefab;   
    public GameObject SkeletonPrefab; 
    public EnemySettings Zombie; //factory returns
    public EnemySettings Skeleton;

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

        // Apply settings based on type
        switch (type)
        {
            case EnemyType.Zombie:
                model.Settings = Zombie;
                break;
            case EnemyType.Skeleton:
                model.Settings = Skeleton;
                break;
        }

        
    }

   
}