using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int maxHealth = 1;
   [SerializeField] int currentHealth;
   [SerializeField] GameObject DeathVFX;
   [SerializeField] GameObject DamageVFX;

   [SerializeField] int starsAwardedOnKill = 0;
    StarDisplay starDisplay;
   
    void Start()
    {
        currentHealth = maxHealth;
        starDisplay = FindObjectOfType<StarDisplay>();
    }
    public int getHealth()
    {
        return currentHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            starDisplay.AddStars(starsAwardedOnKill);
            TriggerDeathVFX();
        }
        else
        {
            TriggerDamageVFX();
        }
    }

    private void TriggerDamageVFX()
    {
        GameObject vfx = Instantiate(DamageVFX, GetComponent<Transform>().position, Quaternion.identity);
        vfx.transform.position = new Vector2(transform.position.x - .5f, transform.position.y -.5f);
        Destroy(vfx, .5f);
    }
    private void TriggerDeathVFX()
    {
        GameObject vfx = Instantiate(DeathVFX, GetComponent<Transform>().position, Quaternion.identity);
        vfx.transform.position = new Vector2(transform.position.x - .5f, transform.position.y -.5f);
        Destroy(vfx, 1f);
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
}
