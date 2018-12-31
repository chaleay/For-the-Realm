using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)] [SerializeField] float movementSpeed = 2f;
    [SerializeField] float offset = 0;
    [SerializeField] bool canJump = true;
    [SerializeField] int damage;
    GameObject currentTarget;
    
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime *movementSpeed);
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public void Die()
    {
        
    }

    public float getOffset()
    {
        return offset;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        GetComponent<Animator>().SetBool("isAttacking", true);
    }

}
