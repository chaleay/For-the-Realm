using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    float timer = 0f;
    Text text;
    [SerializeField] float LevelTime;
    // Update is called once per frame
    [Range(0,1f)] [SerializeField] float volume = 1f;
    [SerializeField] AudioClip timeDoneFX;
    [SerializeField] AudioClip pepFX;

    private bool playedOnce = false;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
       if(LevelTime >= 0)
       {
            LevelTime -= Time.deltaTime;
            text.text = ConvertSecondsToMinuteAndSeconds(LevelTime);
            if(LevelTime < 15f && !playedOnce)
            {
                playedOnce = true;

            }
       }
       else
       {
           text.text = "0";
           //AudioSource.PlayClipAtPoint(TimeDoneFX, Camera.main.transform.position, 1.0f);
           LevelController levelController = FindObjectOfType<LevelController>();
           levelController.levelTimerDone = true;
           levelController.turnOffSpawners();
       }

       
    }

    public string ConvertSecondsToMinuteAndSeconds(float timeToConvert)
    {
        int minute = Mathf.FloorToInt(timeToConvert/60);
        int seconds = Mathf.FloorToInt(timeToConvert%60);
        string convertedTime = (minute == 0) ? ("0" + minute + ":" + seconds): ("0" + minute + ":" + seconds);
        return convertedTime;
            
    }

}
