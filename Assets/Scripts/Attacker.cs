using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    [Header("Movement Speed")]
    [Range(0f,5f)] [SerializeField] float baseMovementSpeed = 1f;
    public float maxMovementSpeedAtThisPoint {get; set;}
    public float currentMovementSpeed {get; set;}
    [SerializeField] float offset = 0;
    [SerializeField] bool canJump = true;
    GameObject currentTarget;
    Animator animator;
    public Attacker attackerInFront {get; set;}

    void Awake()
    {
        FindObjectOfType<LevelController>().numAttackers++;
        Debug.Log(FindObjectOfType<LevelController>().numAttackers);
    }

    void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
            levelController.numAttackers--;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        currentMovementSpeed = maxMovementSpeedAtThisPoint = baseMovementSpeed;
    }
    
    void Update()
    {
        
        //move this attacker every frame
        transform.Translate(Vector2.left * Time.deltaTime * currentMovementSpeed);

        if(animator.GetBool("isIdle"))
        {
            currentMovementSpeed = 0;
        }
        
        //if this attacker was attacking  its target but its target is now dead, proceed to move
        if(animator.GetBool("isAttacking") && !currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
        
        //attacker in front is destroyed, in which case this attacker must move forward
        if(!attackerInFront && animator.GetBool("isIdle"))
        {
            animator.SetBool("isIdle", false);
        }
            
    }

    public void SetMovementSpeed(float movementSpeed)
    {
       maxMovementSpeedAtThisPoint = movementSpeed;
    }

    public float getOffset()
    {
        return offset;
    }

    public void Attack(GameObject target)
    {
       currentTarget = target;
       animator.SetBool("isAttacking", true);
    }

    public bool hasTarget()
    {
        return currentTarget;
    }

    public void WaitForAttackerToFinish()
    {
        animator.SetBool("isIdle", true);
    }

    public void StrikeTarget(int damage)
    {
        if(!currentTarget)
            return;
        Health health = currentTarget.GetComponent<Health>();
        if(health)
            health.DealDamage(damage);
    }

    public bool isIdling()
    {
        return animator.GetBool("isIdle");
    }

    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }

    
    public void Stop()
    {
        currentMovementSpeed = 0f;
    }

    public void Move()
    {
        
        currentMovementSpeed = maxMovementSpeedAtThisPoint;
    }

    public float GetBaseMovementSpeed()
    {
        return baseMovementSpeed;
    }
   
}
