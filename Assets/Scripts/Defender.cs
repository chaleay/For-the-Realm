using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost;

    Animator animator;
     public bool spawned {get; set;} = true;

    void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    public int getCost()
    {
        return cost;
    }

    public void Place()
    {
        spawned = true;
        animator.SetBool("isPlaced", true);
    }
}
