using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Renderer>().sortingLayerName = "Foreground";
         var ForeGroundIconRenderers = GetComponentsInChildren<Renderer>();
         foreach(Renderer renderer in ForeGroundIconRenderers)
         {
             renderer.sortingLayerName = "Foreground Icons";
         }
    }

}
