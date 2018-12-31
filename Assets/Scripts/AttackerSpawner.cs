using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    
    bool spawn = true;
    [SerializeField] List<Attacker> enemiesToSpawn;
    [SerializeField] float minTimeBeforeSpawn = 2f;
    [SerializeField] float maxtimeBeforeSpawn = 6f;
    float timeBeforeSpawn;
    private float update; 
    IEnumerator Start()
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
    

}
