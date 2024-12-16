using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Commands/spawnwave")]
public class SpawnWavesByCommand : Command
{
    [SerializeField] Wave wave;

    public override void Execute()
    {
        wave.SpawnWave();
    }

    public override void Execute(string[] args)
    {
        wave.SpawnWave();
    }
    // Start is called before the first frame update

}
