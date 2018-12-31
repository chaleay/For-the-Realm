using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jojo : MonoBehaviour
{
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
