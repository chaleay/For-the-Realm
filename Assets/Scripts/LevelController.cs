using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int numAttackers {get;set;} = 0;
    public bool levelTimerDone {get;set;} = false;
    private bool hasPlayed = false;
    [SerializeField] AudioClip WinFX;
    [SerializeField] AudioClip LevelStartingFX;
    [Range(0,1f)] [SerializeField] float volume = 1f;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(numAttackers == 0 && levelTimerDone)
        {
            LevelIsFinished();
            levelTimerDone = false;
        }
    }
    //called by Game Begin animation controller

    //THIS SECTION - ENABLE OR DISABLE SPAWNERS - spawners start off by default
    public void EnableSpawners()
    {
        AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.spawn = true;
            StartCoroutine(spawner.SpawnCycle());
        }
    }

    public void turnOffSpawners()
    {
        AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
       //Debug.Log(defenderThisShooterBelongsTo == null); //used to debug weird issue with execution order -- awake and start
       foreach(AttackerSpawner spawner in spawners)
       {
            spawner.spawn = false;
       }
    }

    private void LevelIsFinished()
    {
        
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = WinFX;
        if(!hasPlayed)
        {
            audioSource.Play(0);
            hasPlayed = true;
        }
        GetComponent<Animator>().SetTrigger("WinText");
        StartCoroutine(FindObjectOfType<LevelLoader>().FadeOutAndLoadScene());
    }

    //in the future, it would make more sense to make an array of audioClips. Then the player can just pass an int index and this function will play whatever clip is at that position
    private void PlayOpeningSound()
    {
        audioSource.clip = LevelStartingFX;
        audioSource.Play();
    }
}
