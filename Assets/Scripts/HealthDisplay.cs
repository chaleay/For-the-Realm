using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    
    public int health {get; set;} = 100;
    Text healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void DecreaseHealth(int amount)
    {
        if(amount > health)
            health = 0;
        else
            health -= amount;
        UpdateDisplay();
    }

}
