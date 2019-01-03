using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    
    [Header("Scenes to Load")]
    [SerializeField] int gameOverScene;
    [SerializeField] AudioClip onQuitSFX;
    [SerializeField] float volume = 1f;
    [SerializeField] float timeToWait = 3f;

    void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    public void StartNewGame()
    {
        GetComponent<Animator>().SetTrigger("FadeOut");
    }
   
    public void OnExit()
    {
        //FadeOut();
        AudioSource.PlayClipAtPoint(onQuitSFX, Camera.main.transform.position, volume);
        Application.Quit();
        
    }

    //hint: not every coroutine needs to be ended manually -- once function executes, it halts completely
    
    //used to delay time between when the castle is destroyed and when to initiate the level transition
    public IEnumerator FadeOutAndLoadScene()
    {
        yield return new WaitForSeconds(10f);
        //Fade out scene using Fade Animator
        GetComponent<Animator>().SetTrigger("FadeOut");
    }
  
    public void LoadMainMenuScene()
    {
         SceneManager.LoadScene(1); //1 corresponds to the mainMenu scene
    }
    
    
    //Used In Animator
    public void LoadNextScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Used in Animator
    public void LoadPrevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    
    //"FadeOutManual" loads the menu scene
    public void MainMenuButton()
    {
         GetComponent<Animator>().SetTrigger("FadeOutManual");
    }

}
