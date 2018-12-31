using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
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
        SceneManager.LoadScene("Start Screen");
    }

    public void OnExit()
    {
        FadeOutMusic();
        AudioSource.PlayClipAtPoint(onQuitSFX, Camera.main.transform.position, volume);
        Application.Quit();
        
    }

    public void FadeOutMusic()
    {

    }
}
