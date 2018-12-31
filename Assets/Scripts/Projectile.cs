using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
     [SerializeField] float projectileMoveSpeed = 1f;
     [SerializeField] int damage = 1;

    void Update()
    {
         transform.Translate(Vector2.right * Time.deltaTime * projectileMoveSpeed);
    }

     public void OnTriggerEnter2D(Collider2D otherCollision)
   {
        //Debug.Log("hitting enemy" + otherCollision.gameObject.name);
        DealDamagetoAttacker(otherCollision);
       
   }
    public void DealDamagetoAttacker(Collider2D otherCollision)
    {
        var health = otherCollision.GetComponent<Health>();
        var attacker = otherCollision.GetComponent<Attacker>();
        if(attacker && health)
        {
          health.DealDamage(damage);
          Destroy(gameObject);
        }
    }
}
