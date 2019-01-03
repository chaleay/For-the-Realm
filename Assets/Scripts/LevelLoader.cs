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

    void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadMainMenu());
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
    public IEnumerator FadeOutAndLoadScene()
    {
        yield return new WaitForSeconds(5f);
        //Fade out scene using Fade Animator
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetTrigger("FadeOutManual");
    }

    public void LoadMainMenuScene()
    {
         SceneManager.LoadScene(1); //1 corresponds to the mainMenu scene
    }
    public void LoadNextScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPrevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void MainMenuButton()
    {
         GetComponent<Animator>().SetTrigger("FadeOutManual");
    }

}
