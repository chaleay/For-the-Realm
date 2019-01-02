using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jojo : MonoBehaviour
{
     Attacker attackerInFront;
     Attacker thisAttacker;

    void Start()
    {
        thisAttacker = GetComponent<Attacker>();
    }
    
    private void OnTriggerStay2D(Collider2D otherCollider)
   {
        GameObject other = otherCollider.gameObject;
        Defender otherDefender = other.GetComponent<Defender>();
        Attacker attackerThatCollided = other.GetComponent<Attacker>();
        
        if(otherDefender)
        {
            GetComponent<Attacker>().Attack(other);
        }
        
        //Here, we handle collision for two attackers. There are few cases that might occur:
        //1: one attacker is faster than another, in which case its movement speed must be adjusted to fit the slowest attacker
        //2. 
        if (attackerThatCollided)
        {
            
           
            if(this.transform.position.x > attackerThatCollided.transform.position.x)
            {
                
                attackerInFront = attackerThatCollided;
                thisAttacker.attackerInFront = attackerInFront;
                
                if(attackerInFront.isIdling())
                {
                   //("Idling because AttackerInFront is idling:" + this.name);
                   thisAttacker. WaitForAttackerToFinish();
                }
                
                else if (attackerInFront.getCurrentTarget() != null) //attackerInfront is engaged in combat
                {
                    thisAttacker.WaitForAttackerToFinish();
                }

                else if(attackerInFront.getCurrentTarget() == null && thisAttacker.currentMovementSpeed > attackerInFront.currentMovementSpeed)
                {
                    thisAttacker.maxMovementSpeedAtThisPoint = attackerInFront.currentMovementSpeed;
                }
               
             
            }
        
        }
   }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;
        Attacker attackerThatCollided = other.GetComponent<Attacker>();
        if(attackerThatCollided == attackerInFront)
        {
            attackerInFront = null;
            thisAttacker.attackerInFront = null;
            thisAttacker.maxMovementSpeedAtThisPoint = thisAttacker.GetBaseMovementSpeed();
        }
    }

}
