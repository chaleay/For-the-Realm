using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
   [SerializeField] Projectile typeOfProjectile; 
   [SerializeField] GameObject gun;
   
   [HeaderAttribute("Audio")]
   [SerializeField] AudioClip shootingFX;
   [Range(0,1f)] [SerializeField] float volume = 1f;

   Defender defenderThisShooterBelongsTo;
   AttackerSpawner thisLaneSpawner;
   Animator animator;

  void Awake()
    {
     defenderThisShooterBelongsTo = GetComponent<Defender>();
     animator = GetComponent<Animator>(); 
    }

     //method must be lauched when instantiating a new defender of shooter type
     public void SetLaneSpawner()
     {
       AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
       //Debug.Log(defenderThisShooterBelongsTo == null); //used to debug weird issue with execution order -- awake and start
       foreach(AttackerSpawner spawner in spawners)
       {
         if((Mathf.Abs(spawner.transform.position.y - transform.position.y)) <= Mathf.Epsilon) //mathf.epsilon is the smallest positive infinitesimal
         {
            thisLaneSpawner = spawner;
            Debug.Log("name of spawner: " + thisLaneSpawner.name);
         }
       }
     

     }
     private void Update()
   {
     if(defenderThisShooterBelongsTo.spawned)
     {
      if(AttackerInLane())
      {
       animator.SetBool("IsAttacking", true);
      }
      else
      {
       animator.SetBool("IsAttacking", false);
      }
     }
   }
   

   private bool AttackerInLane()
   {
     if(thisLaneSpawner)
        return thisLaneSpawner.transform.childCount > 0;
     else return false;
   }

   public void Fire()
   {
       if(defenderThisShooterBelongsTo.spawned)
       {
         Projectile projectile = Instantiate(typeOfProjectile, gun.transform.position, transform.rotation); 
       if(shootingFX)
         AudioSource.PlayClipAtPoint(shootingFX, Camera.main.transform.position, volume);
       }
   }
 
}
