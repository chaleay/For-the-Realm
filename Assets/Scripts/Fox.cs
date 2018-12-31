using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
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
