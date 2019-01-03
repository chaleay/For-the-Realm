using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int numAttackers {get;set;} = 0;
    public bool levelTimerDone {get;set;} = false;
    
    
    void Update()
    {
        if(numAttackers == 0 && levelTimerDone)
        {
            LevelIsFinished();
        }
    }
    //called by Game Begin animation controller

    //THIS SECTION - ENABLE OR DISABLE SPAWNERS - spawners start off by default
    public void EnableSpawners()
    {
        AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.spawn = true;
            StartCoroutine(spawner.SpawnCycle());
        }
    }

    public void turnOffSpawners()
    {
        AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
       //Debug.Log(defenderThisShooterBelongsTo == null); //used to debug weird issue with execution order -- awake and start
       foreach(AttackerSpawner spawner in spawners)
       {
            spawner.spawn = false;
       }
    }

    private void LevelIsFinished()
    {

    }
}
