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

    public IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetTrigger("FadeOut");
        Destroy(gameObject, 3f);
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

    public void LoadNextScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
