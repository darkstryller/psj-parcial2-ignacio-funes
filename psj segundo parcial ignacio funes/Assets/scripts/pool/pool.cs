using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class pool 
{
    //diccionario con key enum para poolear todos los objetos
    //se intento usar hashset, pero no funciono, asi que volvi con enums
    //este pool no tiene look up table como en su version original, ya que esta se utilizaba para crear instancias de objetos, el trabajo de factory.
    public static Dictionary<EnemyType, Queue<Component>> poolDictionary = new Dictionary<EnemyType, Queue<Component>>();

    public static void EnqueObject<T>(T item, EnemyType enemy) where T : Component
    {
        if (!item.gameObject.activeSelf) return;

        item.transform.position = Vector2.zero;
        poolDictionary[enemy].Enqueue(item);
        item.gameObject.SetActive(false);

    }

    public static T DequeObject<T>(EnemyType type) where T : Component
    {
        if (poolDictionary[type].TryDequeue(out var item))
            return (T)item;
        
            return null;
    }
    //crea el pool para el juego
    public static void SetupPool<T>(T prefab, int poolsize, EnemyType key) where T : Component
    {
        poolDictionary.Add(key, new Queue<Component>());
        
        for (int i = 0; i < poolsize; i++)
        {
            T pooledInstance = Object.Instantiate(prefab);
            pooledInstance.gameObject.SetActive(false);
            poolDictionary[key].Enqueue(pooledInstance);
        }
    }
}
