using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public bool stopper;

    
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
        for (int i = 0; i < waves.Length; i++)
        {
                stopper = false;
                waves[i].SpawnWave();
                Cooldown(600);

        }

    }
    IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        
    }
}
