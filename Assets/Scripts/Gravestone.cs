using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{

    GameObject currentTarget;
    [SerializeField] int damage;
   private void OnTriggerEnter2D(Collider2D otherCollider)
   {
        GameObject other = otherCollider.gameObject;
        Attacker otherAttacker = other.GetComponent<Attacker>();
        if(otherAttacker)
        {
        Attack(other);
        }
   }

   public void Attack(GameObject target)
   {
       currentTarget = target;
       GetComponent<Animator>().SetBool("isAttacking", true);
   }
}
