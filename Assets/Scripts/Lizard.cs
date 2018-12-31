using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
   
   //since there are dynamic rigidbodies (and both rigidbodies are kinematic) we need to use a trigger
   private void OnTriggerEnter2D(Collider2D otherCollider)
   {
        GameObject other = otherCollider.gameObject;
        Defender otherDefender = other.GetComponent<Defender>();
        if(otherDefender)
        {
        GetComponent<Attacker>().Attack(other);
        }
   }
}
