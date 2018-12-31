using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
   
  
   
    [SerializeField] Defender defenderToSpawn;

    [Header("Background Color")]
    [SerializeField] Color highlightIconColor;
    
    [Header("Text with cost")]
    [SerializeField] Text costText;
    
    //All colors
    SpriteRenderer spriteRenderer;
    DefenderSpawner defenderSpawner;
    Color originalIconColor;
    Color highlightColor = Color.white;
    private static Color originalColor;
    bool thisButtonHighlighted = false;

   void Start()
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
       originalColor = spriteRenderer.color;
       defenderSpawner = FindObjectOfType<DefenderSpawner>();
       costText.text = defenderToSpawn.getCost().ToString();
   }

   public void OnMouseDown()
   {
      if(!thisButtonHighlighted)
      {
        ClickDefenderButton();
      }
      else
      {
          DeselectDefenderButton();
      }
   }

   private void ClickDefenderButton()
   {
        defenderSpawner.FadeOutAllButtons(this); //if this current button is selected, deselect all other buttons except this one if we click on it again
        spriteRenderer.color = highlightColor;
        thisButtonHighlighted = true;
        SetDefenderPrefab(defenderToSpawn);
        defenderSpawner.EnableGhostCursor();
   }

   private void DeselectDefenderButton()
   {
       thisButtonHighlighted = false;
       defenderSpawner.DeselectDefenderButton();
   }

   private void SetDefenderPrefab(Defender defenderToSpawn)
   {
       defenderSpawner.setCurrentDefender(defenderToSpawn);
   }

   public Defender GetDefenderPrefab()
   {
       return defenderToSpawn;
   }


   public static IEnumerator FadeOutButton(DefenderButton button)
   {
    SpriteRenderer spriteRenderer = button.GetComponent<SpriteRenderer>();
       for(float t = .01f; t < 1f; t += .1f)
       {
         spriteRenderer.color = Color.Lerp(spriteRenderer.color, originalColor, t/1f);
         yield return null;
       }
    spriteRenderer.color = originalColor;
   }

   public void setHighlighted(bool isHighlighted)
   {
       thisButtonHighlighted = isHighlighted;
   }
   
   public void UpdateCostTextColor(Color color)
   {
       costText.color = color;
   }
    
}
