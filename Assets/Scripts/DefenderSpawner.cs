using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender currentDefenderSelection;
    //cached array to keep track of all defenders

    [Header("Colors")]
    [SerializeField] Color notEnoughStarTextColor;
    [SerializeField] Color canBuyStarTextColor;
    private List<Defender> defendersOnBoard;
    Defender tempDefender;
    bool ghostCursorEnabled = false;
    StarDisplay starDisplay;
    
    //cached array for all buttons currently on the field
    DefenderButton [] buttons;
  

    void Start()
    {
        defendersOnBoard = new List<Defender>();
        starDisplay = FindObjectOfType<StarDisplay>();
        buttons = FindObjectsOfType<DefenderButton>();      
    }
    
    void Update()
    {
         //CONTROLS FOR SPAWNING DEFENDERS
         //RIGHT CLICK -- disable ghost cursor, no longer spawning
         if(Input.GetMouseButtonDown(1))
         {
            DeselectDefenderButton();
         }
         
         //if we currently have a defender selected
         if(ghostCursorEnabled && currentDefenderSelection)
         {
              tempDefender.transform.position = GetSquareClicked();
         }

         UpdateCostText();
    }
   
   private void OnMouseDown()
    {
        if(currentDefenderSelection)
        {
            SpawnDefender(GetSquareClicked());
        }   
    }
    public void DeselectDefenderButton()
    {
        //this deletes the ghost cursor
        if(tempDefender)
            Destroy(tempDefender.gameObject);
        
        FadeOutAllButtons(null);
        currentDefenderSelection = null;
        ghostCursorEnabled = false;
        
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 posInWorldspace = Camera.main.ScreenToWorldPoint(mousePos);
        return posInWorldspace;
    }
    private void SpawnDefender(Vector2 mousePos)
    {
        Vector2 snapToGridPos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
        if(playerHasEnoughStars())
        {
            Defender newDefender = Instantiate(currentDefenderSelection, snapToGridPos, transform.rotation) as Defender;
            defendersOnBoard.Add(newDefender);
            starDisplay.SpendStars(currentDefenderSelection.getCost());
            InitializeDefender(newDefender);

            
        }
    }

    private void InitializeDefender(Defender defender)
    {
         Shooter shooter = defender.gameObject.GetComponent<Shooter>(); //if component has a shooter attached, set which lane this unit is at
         if(shooter)
         {
            shooter.SetLaneSpawner();
         }

        ResourceGenerator resourceGenerator = defender.gameObject.GetComponent<ResourceGenerator>();
        if(resourceGenerator)
        {
            resourceGenerator.generatorIsPlaced();
        }

        if(defender.gameObject.tag == "Static")
        {
            defender.Place();
        }
           
    }

    
    public bool SquareisOccupied(Vector2 posToCheck)
    {
         foreach(Defender defender in defendersOnBoard)
        {
            Vector2 defenderPos = new Vector2(defender.transform.position.x, defender.transform.position.y);
            //Debug.Log(defenderPos);
            if( defenderPos == posToCheck) //vector2 == operator is overloaded
            {
                //Debug.Log("Already occupied...");
                return true;
            }
        }
        return false;
    }
    
    public void setCurrentDefender(Defender defender)
    {
        currentDefenderSelection = defender;
    }

     public void FadeOutAllButtons(DefenderButton thisButton)
   {
        foreach(DefenderButton button in buttons)
       {
           if(button != thisButton)
           {
             StartCoroutine(DefenderButton.FadeOutButton(button));
             button.setHighlighted(false);
           }
       }
        
   }
   public void EnableGhostCursor()
   {
       if(tempDefender)
        Destroy(tempDefender.gameObject);
       
       tempDefender = Instantiate(currentDefenderSelection, new Vector2(Input.mousePosition.x, Input.mousePosition.y), 
       transform.rotation) as Defender;
       
       //disable collider on ghost object
       tempDefender.GetComponentInChildren<Collider2D>().enabled = false;
       
       //set spawned to false - so defender does not do damage/contribute towards resources
       tempDefender.spawned = false;
       
       //SetAlphaForRenderer(0f);
       ghostCursorEnabled = true;
   }

   private void SetAlphaForRenderer(float amt)
   {
       var allSpriteColors = tempDefender.GetComponentsInChildren<SpriteRenderer>();
       
       foreach(SpriteRenderer renderer in allSpriteColors)
       {
           Color ghostColor = renderer.color;
           ghostColor.a = amt;
           renderer.color = ghostColor;
       }   
   }

   private void UpdateCostText()
   {
         foreach(DefenderButton button in buttons)
            if(starDisplay.getStars() >= button.GetDefenderPrefab().getCost())
            {
                button.UpdateCostTextColor(canBuyStarTextColor);
            }
            else
                button.UpdateCostTextColor(notEnoughStarTextColor);
   }

   private bool playerHasEnoughStars()
   {
       return starDisplay.getStars() >=  currentDefenderSelection.getCost();
   }
}
