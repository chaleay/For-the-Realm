using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    Attacker currentAttacker;
   
   
   
   private void Update()
   {
       if(!currentAttacker)
       {
        GetComponent<Animator>().SetBool("isAttacking", false);
       }
   }
   private void OnTriggerEnter2D(Collider2D otherCollider)
   {
        GameObject other = otherCollider.gameObject;
        Attacker otherAttacker = other.GetComponent<Attacker>();
        if(otherAttacker && !otherAttacker.GetComponent<Fox>())
        {
        setAttacker(otherAttacker);
        //Debug.Log(otherAttacker.name + "is in this gravestone's collider");
        }
        
   }

   public void setAttacker(Attacker otherAttacker)
   {
       currentAttacker = otherAttacker;
       GetComponent<Animator>().SetBool("isAttacking", true);
   }

   public void StrikeAttacker(int damage)
   {
        if(currentAttacker)
        {
            Health health = currentAttacker.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
   }
}
