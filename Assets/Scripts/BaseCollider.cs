﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
   
   
    HealthDisplay healthDisplay;
    Animator animator;
    [SerializeField] GameObject CastleDeathVFX;

   void Start()
   {
       healthDisplay = FindObjectOfType<HealthDisplay>();
       animator = GetComponent<Animator>();
       
   }
   private void OnTriggerEnter2D(Collider2D collider)
   {
       Destroy(collider.gameObject);
       healthDisplay.DecreaseHealth(10);
       animator.SetTrigger("hurt");
       if(healthDisplay.health <= 0)
       {
           LoseGame();
       }
   }

   private void LoseGame()
   {
       GetComponent<Collider2D>().enabled = false;
       animator.SetBool("isDead", true);
       FindObjectOfType<LevelController>().turnOffSpawners();
       StartCoroutine(FindObjectOfType<LevelLoader>().FadeOutAndLoadScene());
   }

   

    public void DestroyCastle()
    {
       GameObject vfx = Instantiate(CastleDeathVFX, transform.GetChild(0).transform.position, Quaternion.identity
       );
       Debug.Log(vfx.transform.position);
       Destroy(vfx, 3f);
    }
}
