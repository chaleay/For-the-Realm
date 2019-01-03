using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    
    public bool spawn {get;set;} = false;
    [SerializeField] List<Attacker> enemiesToSpawn;
    [SerializeField] float minTimeBeforeSpawn = 2f;
    [SerializeField] float maxtimeBeforeSpawn = 6f;
    float timeBeforeSpawn;
    private float update; 
    Coroutine spawnCycle;


    public IEnumerator SpawnCycle()
    {
         while(spawn)
        {
            timeBeforeSpawn = Random.Range(minTimeBeforeSpawn, maxtimeBeforeSpawn);
            yield return new WaitForSeconds(timeBeforeSpawn);
            SpawnAttacker();
        }
    }
    public void SpawnAttacker()
    {
        
        Attacker attackerToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
        Vector2 areaToSpawn = new Vector2(transform.position.x + attackerToSpawn.getOffset(), transform.position.y);
        Attacker enemy = Instantiate(attackerToSpawn, areaToSpawn, transform.rotation) as Attacker;
        enemy.transform.parent = transform;
        
    }

    public void changeMinSpawnTime(float time)
    {
        minTimeBeforeSpawn = time;

    }

    public void changeMaxSpawnTime(float time)
    {
        maxtimeBeforeSpawn = time;

    }

    

}
