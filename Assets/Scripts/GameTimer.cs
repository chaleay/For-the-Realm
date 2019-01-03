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
       }
       else
       {
           text.text = "0";
           FindObjectOfType<LevelController>().levelTimerDone = true;
       }
       
    }

    public string ConvertSecondsToMinuteAndSeconds(float timeToConvert)
    {
        int minute = Mathf.FloorToInt(timeToConvert/60);
        int seconds = Mathf.FloorToInt(timeToConvert%60);
        return minute + ":" + seconds;
    }

}
