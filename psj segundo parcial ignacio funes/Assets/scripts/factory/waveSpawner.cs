using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public bool stopper;
    [SerializeField] float interval = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {
         
        stopper = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        SpawnWave();

    }

    void SpawnWave()
    {
        
        if (stopper)
        {
            stopper = false;
            StartCoroutine(Spawner(interval));
        }
       

    }
    IEnumerator Spawner(float time)
    {
        for (int i = 0; i < waves.Length; i++)
        {

            waves[i].SpawnWave();
            yield return new WaitForSeconds(time);

        }
        
        
    }
}
