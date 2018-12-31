using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [Header("Generator Properties")]
    [SerializeField] int numOfCyclesBeforeGenerate = 2;
    [SerializeField] int resourcesGenerated;
    int numCurrentCycles;
    Animator animator;
    Defender defenderThisBelongsTo;
   
   void Awake()
   {
     defenderThisBelongsTo = GetComponent<Defender>();
     animator = GetComponent<Animator>();   
   }
    
    public void completeCycle(int cycle)
    {
      if(defenderThisBelongsTo.spawned)
      {
         numCurrentCycles += cycle;
         if(numCurrentCycles >= numOfCyclesBeforeGenerate)
         {
            AddStars();
            numCurrentCycles = 0;
         }
      }
    }

    public void generatorIsPlaced()
    {
        defenderThisBelongsTo.spawned = true;
        animator.SetBool("isPlaced", true);
    }

    public int getCurrentCycle()
    {
        return numCurrentCycles;
    }

    public void AddStars()
    {
        FindObjectOfType<StarDisplay>().AddStars(resourcesGenerated);
    }

    public Defender getDefenderAttached()
    {
        return defenderThisBelongsTo;
    }
}
